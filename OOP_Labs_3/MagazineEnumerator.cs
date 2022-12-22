namespace OOP_Labs_3;

class MagazineEnumerator
{
    public List<Article> people;

    public MagazineEnumerator(List<Person> editors, List<Article> articles)
    {
        this.people = new List<Article>();
        foreach (Article article in articles)
        {
            if (!editors.Contains(article.author))
                this.people.Add(article);
        }
    }
}