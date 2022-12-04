using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Restschuldrechner;

public class RestschuldViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private double _kreditSumme = 150000;
    private double _tilgungsSatz = 1.5f;
    private int _zinsbindung = 15;
    private double _zinsfuss = 1.5f;

    private double _zahlungen;
    private double _rsk;
    private double _tilgung;
    private double _zinszahlungen;
    private double _anteilRestschuld;


    /// <summary>
    /// Kreditsumme (S)
    /// </summary>
    public double KreditSumme
    {
        get => _kreditSumme;
        set
        {
            if (_kreditSumme == value) { return; }
            _kreditSumme = value;
            OnPropertyChanged();
            Calculate();
        }
    }

    /// <summary>
    /// Zinsfuß (p)
    /// </summary>
    public double Zinsfuss
    {
        get => _zinsfuss;
        set
        {
            if (_zinsfuss == value) { return; }
            _zinsfuss = value;
            OnPropertyChanged();
            Calculate();
        }
    }


    /// <summary>
    /// Tilgungsssatz (t)
    /// </summary>
    public double TilgungsSatz
    {
        get => _tilgungsSatz;
        set
        {
            if (_tilgungsSatz == value) { return; }
            _tilgungsSatz = value;
            OnPropertyChanged();
            Calculate();
        }
    }

    /// <summary>
    /// Zinsbindung in Jahren (k)
    /// </summary>
    public int Zinsbindung
    {
        get => _zinsbindung;
        set
        {
            if (_zinsbindung == value) { return; }
            _zinsbindung = value;
            OnPropertyChanged();
            Calculate();
        }
    }

    /// <summary>
    /// Anteil der Restschuld an der Gesamtschuld
    /// </summary>
    public double AnteilRestschuld
    {
        get => _anteilRestschuld;
        set
        {
            _anteilRestschuld = Math.Max(0, value);
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Summe der Zinszahlungen während der Zinsbindung
    /// </summary>
    public double Zinszahlungen
    {
        get => _zinszahlungen;
        set
        {
            _zinszahlungen = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Höhe der Tilgung während der Zinsbindung
    /// </summary>
    public double Tilgung
    {
        get => _tilgung;
        set
        {
            _tilgung = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///  Restschuld am Ende der Laufzeit
    /// </summary>
    public double Restschuld
    {
        get => _rsk;
        set
        {
            _rsk = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gesamtzahlungen während der Laufzeit
    /// </summary>
    public double Zahlungen
    {
        get => _zahlungen;
        set
        {
            _zahlungen = value;
            OnPropertyChanged();
        }
    }


    private void Calculate()
    {
        // Zinssatz pro Jahr (i)
        var i = Zinsfuss / 100;

        // Zinssatz pro Monat (im)
        var im = i / 12;

        // Zinsfaktor pro Monat (qm)
        var qm = im + 1;

        // Zinsbindung in Monaten
        var km = Zinsbindung * 12;

        // jährliche Annuität (A)
        var annuitaet = KreditSumme * (i + TilgungsSatz / 100);

        // monatliche Annuität (a)
        var a = annuitaet / 12;

        // Gesamtzahlungen während der Laufzeit
        Zahlungen = annuitaet * Zinsbindung;

        // Restschuld am Ende der Laufzeit / Jahr k (RSk)
        Restschuld = KreditSumme - (Math.Pow(qm, km) - 1) / im * (a - im * KreditSumme);

        // Tilgung 
        Tilgung = KreditSumme - Restschuld;
        Zinszahlungen = Zahlungen - Tilgung;

        AnteilRestschuld = 250d / KreditSumme * Restschuld;

    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
