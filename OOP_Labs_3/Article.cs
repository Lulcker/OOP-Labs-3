namespace OOP_Labs_3;

class Article : IRateAndCopy
{
    public Person author;
    public string title;
    public double rait;

    public Article()
    {
        this.author = new Person();
        this.rait = 0;
        this.title = "";
    }

    public Article(Person author, string title, double rait)
    {
        this.author = author;
        this.title = title;
        this.rait = rait;
    }

    public override string ToString()
    {
        return "Титл: " + this.title +
               "\nРейтинг: " + this.rait.ToString() +
               "\nИнформация об авторе: " + this.author.ToString();
    }

    double IRateAndCopy.Rating => this.rait;

    object IRateAndCopy.DeepCopy()
    {
        return new Article(this.author, this.title, this.rait);
    }

}