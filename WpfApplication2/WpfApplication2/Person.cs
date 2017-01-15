using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }

    }

    public static class PersonManager
    {
        private static readonly Lazy<ObservableCollection<Person>> personHolder =
            new Lazy<ObservableCollection<Person>>
            (
                () =>
                {
                    var r = new Random();
                    return new ObservableCollection<Person>(
                        Enumerable.Range(0, 5).Select(
                            i => new Person { Id = Guid.NewGuid(), Age = r.Next(), Name = "Person" + i.ToString() }
                            )
                        );
                },
                true
            );

        public static ObservableCollection<Person> PersonList
        {
            get { return personHolder.Value; }
        }

    }
}
