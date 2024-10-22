using System;
/*  
*/
namespace test11
{
    class MusicSentimentalValue : Music
    {
        public string sentimental 
        {get; set;}
        public MusicSentimentalValue()
        {
            sentimental = "Money is stupid. ";
        }

        public MusicSentimentalValue(string musicArtist, int musicCatalogSize) 
        {
            base.artist = musicArtist;
            base.catalogSize = musicCatalogSize;         
        }

        public override void Sound()
        {
            Console.WriteLine("Artists make cheap songs. ");
        }   
        
        public override string ToString()
        {
            return ("Your " + base.catalogSize + " albums from " + base.artist + " are worth " + "more than any dollar amount. ");
        }
        
    }
 } 
