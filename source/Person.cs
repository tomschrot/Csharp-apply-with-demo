using System;

namespace test {
    
    public sealed class Person {

        //FIXME: For uniqueness, you may prefer a non generic delegate type!
        public delegate void Utilize(Person p);
        //FIXME: Instead of Action<Person>.

        public string firstname {get; set;} = "";
        public string lastname  {get; set;} = "";
        public string city      {get; set;} = "";

        public string asString {
            get => $"{firstname} {lastname}, {city}";
        }

        /// <summary>
        /// Standard ctor.
        /// </summary>
        public Person(){}
        
        /// <summary>
        /// Configuration constructor.
        /// </summary>
        /// <param name="config">Lambda to configure the object.</param>
        /// 
        public Person(Utilize config) => config(this);

        // FIXME: Sure, .NET Action type does the same job:
        // public Person( Action<Person> action) => action(this);

        public void capitalize() {
            firstname = this.firstname.ToUpper();
            lastname  = this.lastname .ToUpper();
            city      = this.city     .ToUpper();
        }

        override public string ToString() => asString;
    }
}