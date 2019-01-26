using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Challenge 1: Invoke an event if a person’s name is changed
//Create a class Person which has a property “Name”. Your task is to invoke an event that checks if a person’s
//name has changed or not and assign a new value to a person name.

namespace StudyLab._5___ChapterFive.ChallengeOne
{
    public class ChapterFiveChallengeOne : IExerciseContent
    {
        public void Execute()
        {
            Person person = new Person();
            person.PropertyNameChanged += OnPropertyChanged;
            person.PropertyEmailChanged += OnPropertyEmailChanged;
            person.PersonName = "Leandro";
            person.Email = "leandro@andrioli.com";
        }
        private static void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Person person = (Person)sender;
            Console.WriteLine("Property [{0}] has a new value = [{1}]",
                e.PropertyName, person.PersonName);
        }

        private static void OnPropertyEmailChanged(object sender, EventArgs e)
        {
            Person person = (Person)sender;
            Console.WriteLine("Property [{0}] has a new value = [{1}]",
                "email", person.Email);
        }
    }

    public class Person
    {
        private string _name;

        private string _email;

        public event PropertyChangedEventHandler PropertyNameChanged;

        public event EventHandler PropertyEmailChanged;

        public string PersonName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyNameChanged("PersonName");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyEmailChanged("Email");
            }
        }

        private void OnPropertyEmailChanged(string email)
        {
            PropertyEmailChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnPropertyNameChanged(string name)
        {
            PropertyNameChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
