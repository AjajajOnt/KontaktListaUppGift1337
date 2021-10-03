using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktListaUppGift1337
{
    public class Person
    {


        public string name { get; set; }
        public string lastname { get; set; }
        public string alias { get; set; }
        public int age { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string emailAddress1 { get; set; }
        public string linkedInProfile { get; set; }
        public string facebookProfile { get; set; }
        public string instagramProfile { get; set; }
        public string twitterProfile { get; set; }
        public string steamProfile { get; set; }
        public string githubSite { get; set; }
        public string favoriteFood { get; set; }
        public string favoritAnimal { get; set; }
        public string favoriteMovieGenre { get; set; }
        public string favoriteMovie{ get; set; }
        public string Name { get; internal set; }

        public bool blocked = false;
        public bool ghosted = false;

    }
}
