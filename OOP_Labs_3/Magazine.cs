namespace OOP_Labs_3;

class Magazine : Edition, IRateAndCopy
    {
        private Frequency frequency;
        private List<Article> articles;
        protected List<Person> editors;
        public Magazine(
            string name,
            Frequency frequency,
            DateTime release_time,
            int circulation
        ) : base(name, release_time, circulation)
        {
            this.frequency = frequency;
            this.articles = new List<Article>();
            editors = new List<Person>();
        }

        public Magazine() : base()
        {
            this.frequency = Frequency.Weekly;
            this.articles = new List<Article>();
            editors = new List<Person>();
        }

        public Edition Edition
        {
            get { return new Edition(name, release_time, circulation); }
            set
            {
                this.name = value.Name;
                this.release_time = value.ReleaseTime;
                this.circulation = value.Circulation;
            }
        }
        public double MeanRaiting
        {
            get
            {
                if (this.Articles.Count == 0)
                    return 0;
                return this.Articles.Sum(a => a.rait) / this.Articles.Count;
            }
        }
        public bool CheckFrequency(Frequency value)
        {
            return value == this.frequency;
        }

        public void AddArticles(Article[] new_articles)
        {
            this.Articles.AddRange(new_articles);
        }
        public void AddEditors(Person[] new_redactors)
        {
            this.editors.AddRange(new_redactors);
        }
        public new Magazine DeepCopy()
        {
            Magazine magazine = new Magazine(this.name, this.frequency, this.release_time, this.circulation);
            magazine.AddArticles(this.articles.ToArray());
            magazine.AddEditors(this.editors.ToArray());
            return magazine;
        }
        object IRateAndCopy.DeepCopy()
        {
            Magazine magazine = new Magazine(this.name, this.frequency, this.release_time, this.circulation);
            magazine.AddArticles(this.articles.ToArray());
            magazine.AddEditors(this.editors.ToArray());
            return magazine;
        }
        double IRateAndCopy.Rating => this.MeanRaiting;

        public virtual string ToShortString()
        {
            return "Название: " + this.name +
                    "\nfrequency: " + this.frequency.ToString() +
                    "\nДата релиза: " + this.release_time.ToString() +
                    "\nТираж: " + this.circulation.ToString() +
                    "\nСредний рейтинг: " + this.MeanRaiting.ToString();
        }

        public override string ToString()
        {
            string res = (
                "Название: " + this.name +
                "\nfrequency: " + this.frequency.ToString() +
                "\nДата релиза: " + this.release_time.ToString() +
                "\nТираж: " + this.circulation.ToString() +
                "\nArticles:\n"
            );
            if (this.articles.Count == 0)
                res += "No articles";
            else
                foreach (Article article in this.articles)
                {
                    res += article.ToString() + '\n';
                }
            res += "Editors:\n";
            if (this.editors.Count == 0)
                res += "No editors";
            else
                foreach (Person redactor in this.editors)
                {
                    res += redactor.ToString() + '\n';
                }
            return res;
        }

        public Frequency Frequency
        {
            get { return this.frequency; }
            set { this.frequency = value; }
        }
        public List<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
        public List<Person> Editors
        {
            get { return this.editors; }
        }
    }