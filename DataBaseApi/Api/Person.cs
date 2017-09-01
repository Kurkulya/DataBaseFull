namespace DataBaseApi
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(int Id, string FirstName, string LastName, int Age)
        {
            Init(Id, FirstName, LastName, Age);
        }
        public Person()
        {

        }
        public void Init(int Id, string FirstName, string LastName, int Age)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }
    }
}