namespace OOP_Labs_3;

class MagazineCollection
    {
        private List<Magazine> magazines = new List<Magazine>();

        public void AddDefault(int count)
        {
            this.magazines.AddRange(new List<Magazine>(count));
        }

        public void AddMagazines(Magazine[] magazines)
        {
            this.magazines.AddRange(magazines);
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < magazines.Count; i++)
            {
                res += "Magazine " + i.ToString() + ":\n" + magazines[i].ToString() + "\n\n";
            }
            return res;
        }
        public virtual string ToShortString()
        {
            string res = "";
            for (int i = 0; i < magazines.Count; i++)
            {
                res += (
                    "Magazine " + i.ToString() + ":\n" +
                    magazines[i].ToShortString() +
                    "\nArticles count: " + magazines[i].Articles.Count +
                    "\nEditors count: " + magazines[i].Editors.Count + "\n\n"
                );
            }
            return res;
        }

        public void SortByName()
        {
            this.magazines.Sort((x, y) => x.Name.CompareTo(y.Name));
        }

        public void SortByRelease()
        {
            IComparer<Edition> comparer = new Edition();
            this.magazines.Sort(
                delegate (Magazine m1, Magazine m2)
                {
                    return comparer.Compare(m1.Edition, m2.Edition);
                }
            );
        }

        public void SortByCirculation()
        {
            this.magazines.Sort(new EditionComparer());
        }

        public double MaxRaiting
        {
            get
            {
                return this.magazines.Max(m => m.MeanRaiting);
            }
        }
        public List<Magazine> MonthlyMagazines
        {
            get
            {
                return this.magazines.Where(m => m.Frequency == Frequency.Monthly).ToList();
            }
        }
        public List<Magazine> RaitingGroup(double value)
        {
            return this.magazines.Where(m => m.MeanRaiting > value).ToList();
        }
    }