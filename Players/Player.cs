namespace Players
{
    internal class Player
    {
        private string _imie;
        private string _nazwisko;
        private int _wiek;
        private double _waga;

        public Player(string imie, string nazwisko, int wiek, double waga)
        { }

        public Player() { }

        public Player(string w)
        {
            string[] s = w.Split();
            this._imie = s[0];
            this._nazwisko = s[1].Remove(s[1].Length - 1, 1);
            this._wiek = int.Parse(s[2]);
            this._waga = double.Parse(s[4]);
        }

        public Player(Player p)
        {
            this._imie = p._imie;
            this._nazwisko = p._nazwisko;
            this._wiek = p._wiek;
            this._waga = p._waga;
        }
        ~Player() { }

        public override string ToString()
        {
            return  _imie + " " + _nazwisko + ", " + _wiek.ToString() + " lat, " + _waga.ToString() + " kg";
        }
        public string Imie
        {
            get => _imie;
            set => _imie = value;
        }

        public string Nazwisko
        {
            get => _nazwisko;
            set => _nazwisko = value;
        }

        public int Wiek
        {
            get => _wiek;
            set => _wiek = value;
        }

        public double Waga
        {
            get => _waga;
            set => _waga = value;
        }
        
    }
}