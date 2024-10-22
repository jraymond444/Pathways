using System;
/*  
*/
namespace test11
{
    class MusicValue : Music
    {
        public int value
        {get; set;}
        public MusicValue()
        {
            value = 15;
        }

        public int getValue(int value)
        {
            int totalValue = value * base.catalogSize;
            return totalValue;
        }   
        public MusicValue(string musicArtist, int musicCatalogSize, int musicValue):base(musicArtist,musicCatalogSize)
        {
            //base.artist = musicArtist;
            //base.catalogSize = musicCatalogSize;
            this.value = getValue(musicValue);                
        }
        public override void Sound()
        {
            Console.WriteLine("Artists make expensive songs. ");
        }   
        public override string ToString()
        {
            return ("Your " + base.catalogSize + " albums from " + base.artist + " are worth " + "$" + this.value);
        }
        
    }
 } 
