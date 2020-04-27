using System.Text;
using System.Collections.ObjectModel;

using static Functional.Extensions; 

namespace test {

    public sealed class PersonList {

        public static PersonList operator + (PersonList l, Person p) =>
                l.apply( me => l.list.Add(p) );

        public Collection<Person> list {get; private set;} = new Collection<Person>();
        
        public PersonList add(Person p) => (this + p);

        // FIXME: Matter of taste using generic Action<Person>??
        // public PersonList add( Action<Person> action ) => (this + new Person(action));

        public PersonList add( Person.Utilize config ) => (this + new Person(config));

        public PersonList forEach( Person.Utilize use ) => 
                            this.apply( me => {
                                foreach(var p in list)
                                    use(p);
                            });

        public string asString {   
            get => 
                with(new StringBuilder(), sb => {
                    sb.Append("Citizens:\n");
                    forEach(p => sb.Append($"{p.firstname} {p.lastname} from {p.city}\n"));
                }).ToString();
        }

        override public string ToString() => asString;
    }
}