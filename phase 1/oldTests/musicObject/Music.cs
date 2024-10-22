using System;
/*  
*/
namespace test11
{
    class Music
    {
        public string artist
        {get; set;}
        public int catalogSize
        {get; set;}

        public Music()
        {
            artist = "Artist";
            catalogSize = 5;
        }
        public virtual void Sound()
        {
            Console.WriteLine("Artists make songs. ");
        }   
        public Music(string musicArtist, int musicCatalogSize) 
        {
            this.artist = musicArtist;
            this.catalogSize = musicCatalogSize;
        }
        
        public override string ToString()
        {
            return ("You have " + this.catalogSize + " albums from " + this.artist);
        }
        
    }
 } 
