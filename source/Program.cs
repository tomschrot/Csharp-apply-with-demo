using System.Linq;
using System;

using static Functional.Extensions;

namespace test {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("C# Functional");
            Console.WriteLine("apply / with Demo");
            Console.WriteLine("(c) Tom Schröter\n");

            // In the common way, new objects are created like this:
            // (no encapsulation at all!)
            var p = new Person();
            p.firstname = "Donald";
            p.lastname  = "Duck";
            p.capitalize();
            // etc.

            // Using a object initialzer can be helpful.
            // But it does not allow access to all members of the object
            // and breakes the encapulation context!
            var p1 = new Person { 
                            firstname = "Donald", // inside
                            lastname  = "Duck"  , // inside
                            // etc.
                    };
            p1.capitalize(); // outside

            // Instead of the object initializer, the functional approach
            // is more flexible. It allows access to all members during 
            // object creation and does not break encapsulation.
            // But it reqires a constructor that takes,
            // how I call it, a "configuration lambda" or configurator. 
            // (Is it a Pattern...?)
            var p2 = new Person( me => {
                            me.firstname = "Donald";
                            me.lastname  = "Duck";
                            me.capitalize();
                            // etc. Everything inside.
                    });

            // Unfortunately most legacy code does not have a configurator!
            // So an extension method apply() could solve it:
            var p3 = new Person().apply( me => {
                            me.firstname = "Donald";
                            me.lastname  = "Duck";
                            me.capitalize();
                            // etc.
                    });

            // Let's see how such objects can be collected:
            var citizens = new PersonList();
            
            var p4       = new Person();
            p4.firstname = "Donald";
            p4.lastname  = "Duck";
            citizens.add(p4);

            var p5       = new Person();
            p5.firstname = "Dagobert";
            p5.lastname  = "Duck";
            citizens.add(p5);

            var p6       = new Person();
            p6.firstname = "Gustav";
            p6.lastname  = "Gans";
            citizens.add(p6);

            // etc.
            // Straight forward, but somehow... bulky?!

            // The functional approach is IMHO readable and elegant:
            var smartCitizens = 
                    new PersonList()
                        .add( pers => {
                                pers.firstname = "Donald";
                                pers.lastname  = "Duck";
                                pers.city      = "Ententhausen"; 
                        })
                        .add( pers => {
                                pers.firstname = "Dagobert";
                                pers.lastname  = "Duck";
                                pers.city      = "Ententhausen";
                                pers.capitalize();
                        })
                        .add( pers => { 
                                pers.firstname = "Gustav"; 
                                pers.lastname  = "Gans"; 
                                pers.city      = "Entenhausen";
                        })
                        .forEach( person => person.firstname = "Mr. " + person.firstname );

            Console.WriteLine( smartCitizens );
        }
    }
}
