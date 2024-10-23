
window.onload = function(){
    document.getElementById("city").addEventListener("keydown",function(event){
    if (event.key === "Enter"){
        event.preventDefault();
        getCoordinates();
        }
    });
}

async function getCoordinates(){

    const cityLookup = document.getElementById("city").value;

    if (cityLookup === ""){
        alert("Please enter a city name.");
        return;
    }
    const cityHeader = document.getElementById('cityHeader');
    
    
    cityHeader.textContent = `${cityLookup}`;
    const geoCodingUrl = `https://nominatim.openstreetmap.org/search?q=${encodeURIComponent(cityLookup)}&format=json&limit=1`;

    // now use the fetch API to make the HTTP request
    var responseGeoCodingURL = await fetch(geoCodingUrl);  //note response is a promise object
    // read the response as JSON since it is a JSON file
    var jsonDataGeoCodingURL = await responseGeoCodingURL.json();  
    if (jsonDataGeoCodingURL.length > 0){
        const latitude = jsonDataGeoCodingURL[0].lat;
        const longitude = jsonDataGeoCodingURL[0].lon;
        getGridInfo(latitude, longitude);
    } 
    else {
        console.error('City not found.');
    }
    document.forms["cityForm"]["city"].value = "";
}
async function getGridInfo(latitude,longitude){
    const pointsApiUrl =   `https://api.weather.gov/points/${latitude},${longitude}`;

    var responseGetGrid = await fetch(pointsApiUrl);
    var jsonDataGetGrid = await responseGetGrid.json();

    console.log('Points API response:', jsonDataGetGrid);

    const wfo = jsonDataGetGrid.properties.gridId;  
    const gridX = jsonDataGetGrid.properties.gridX;
    const gridY = jsonDataGetGrid.properties.gridY;

    getHourlyForecast(wfo,gridX,gridY)
}
async function getHourlyForecast(wfo,gridX,gridY){
    const forecastUrl = `https://api.weather.gov/gridpoints/${wfo}/${gridX},${gridY}/forecast/hourly`;

    var responseForecast = await fetch(forecastUrl);
    var jsonDataForecast = await responseForecast.json();

    console.log('forecast response:', jsonDataForecast);

    displayForecast(jsonDataForecast);
}
async function displayForecast(jsonDataForecast){
    const forecastElement = document.getElementById('forecastTable');
    forecastElement.innerHTML = ' ';

    const forecastTable = document.createElement('table');

    const headerRow = forecastTable.insertRow();
    headerRow.innerHTML = `
    <th>Time</th>
    <th>Percipitation chance</th>
    <th>Temperature</th>
    <th>Wind Speed</th>
    <th>Conditions</th>
    `;

    jsonDataForecast.properties.periods.slice(0,12).forEach(period => {
        const row = forecastTable.insertRow();
        const time = new Date(period.startTime).toLocaleTimeString([], {hour: '2-digit', minute: '2-digit'});
        const percipitation = period.probabilityOfPrecipitation?.value ?? 'NA';
        const windSpeed = period.windSpeed;
        const shortForecast = period.shortForecast;
        const temperature = `${period.temperature} ${period.temperatureUnit}`;

        let icon = ' ';

        if (shortForecast.includes('Sunny') || shortForecast.includes('Clear')){
            icon = `<img src="icons/sunny.jpg" class="weather-icon">`;
        };

        if (shortForecast.includes('Mostly') || shortForecast.includes('Partly')){
            icon = `<img src="icons/partlyCloudy.jpg" class="weather-icon">`;
        };

        if (percipitation !== 'N/A' && percipitation > 19 && shortForecast.includes('Rain')){
            icon = `<img src="icons/rainy.jpg" class="weather-icon">`;
        };

        const windSpeedInt = parseInt(windSpeed);
        if (windSpeedInt > 15){
            icon = `<img src="icons/windy.jpg" class="weather-icon">`;
        }

        row.innerHTML = `
        <td>${time}</td>
        <td>${percipitation}</td>
        <td>${temperature}</td>
        <td>${windSpeed}</td>
        <td>${shortForecast}</td>
        <td>${icon}</td>`;
    });
    forecastElement.appendChild(forecastTable);
}