using System;
using System.Windows.Forms;
using System.Drawing;

namespace Liczebniki
{
    public partial class Liczebniki_Form : Form
    {
        private string[] jedności =     {
                                            "zero ",
                                            "jeden ",
                                            "dwa ",
                                            "trzy ",
                                            "cztery ",
                                            "pięć ",
                                            "sześć ",
                                            "siedem ",
                                            "osiem ",
                                            "dziewięć "
                                        };
        private string[] naście =       {
                                            "dziesięć ",
                                            "jedenaście ",
                                            "dwanaście ",
                                            "trzynaście ",
                                            "czternaście ",
                                            "piętnaście ",
                                            "szesnaście ",
                                            "siedemnaście ",
                                            "osiemnaście ",
                                            "dziewiętnaście "
                                        };
        private string[] dziesiątki =   {
                                            string.Empty,
                                            "dziesięć ",
                                            "dwadzieścia ",
                                            "trzydzieści ",
                                            "czterdzieści ",
                                            "pięćdziesiąt ",
                                            "sześćdziesiąt ",
                                            "siedemdziesiąt ",
                                            "osiemdziesiąt ",
                                            "dziewięćdziesiąt "
                                        };
        private string[] setki =        {
                                            string.Empty,
                                            "sto ",
                                            "dwieście ",
                                            "trzysta ",
                                            "czterysta ",
                                            "pięćset ",
                                            "sześćset ",
                                            "siedemset ",
                                            "osiemset ",
                                            "dziewięćset "
                                        };


        public Liczebniki_Form()
        {
            InitializeComponent();
        }   //constructor - Liczebniki_Form

        private void Liczba_textBox_TextChanged(object sender, EventArgs e)
        {
            this.Mark_changes();
        }   //Liczba_textBox_TextChanged

        private void Liczba_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.Przepisz_button_Click(null, null);
            }
        }   //Liczba_textBox_KeyPress

        private void Liczebnik_richTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Mark_changes();
        }   //Liczebnik_richTextBox_TextChanged

        private void Przepisz_button_Click(object sender, EventArgs e)
        {
            try
            {
                //korekta, sprawdzenie i przygotowanie danych wejściowych (w tym zaokrąglenie do dwóch miejsc po przecinku) 
                string liczba = this.Liczba_textBox.Text.Replace('.', ',');
                liczba = liczba.Replace(" ", "");
                liczba = double.Parse(liczba).ToString("F2");
                int comma_idx = liczba.IndexOf(',');
                if (comma_idx > 12)
                {
                    MessageBox.Show
                        (
                        "Za duża kwota.\n" +
                        "Max: 999 999 999 999,99",
                        "BŁĄD #1"
                        );
                    return;
                }
                char[] cyfry = liczba.ToCharArray();
                //wstawienie spacji co tyrzy cyfry w danych wejściowych
                string nowa_liczba = liczba;
                int nowy_comma_idx = nowa_liczba.IndexOf(',');
                if (nowy_comma_idx > 3)
                {
                    nowa_liczba = nowa_liczba.Insert(nowy_comma_idx - 3, " ");
                }
                nowy_comma_idx = nowa_liczba.IndexOf(',');
                if (nowy_comma_idx > 7)
                {
                    nowa_liczba = nowa_liczba.Insert(nowy_comma_idx - 7, " ");
                }
                nowy_comma_idx = nowa_liczba.IndexOf(',');
                if (nowy_comma_idx > 11)
                {
                    nowa_liczba = nowa_liczba.Insert(nowy_comma_idx - 11, " ");
                }
                this.Liczba_textBox.Text = nowa_liczba;
                //właściwe przetwarzanie liczby na liczebnik
                string wynik = "";
                for (int i = comma_idx - 1; i >= 0 ; i--)
                {
                    switch (comma_idx - i)  //kolejne cyfry od jedności (najmłodsza, przed przecinkiem, ma indeks = 1)
                    {
                        case 1: //jedności (10^0)
                            {
                                wynik = this.Trzy_cyfry(cyfry, i) + wynik;
                                break;
                            }
                        case 2: //dziesiątki (10^1)
                            break;  //bo wszystkie czynności w "case 1:"
                        case 3: //setki (10^2)
                            break;  //bo wszystkie czynności w "case 1:"
                        case 4: //tysiące (10^3)
                            {
                                wynik = this.Trzy_cyfry(cyfry, i) + this.Tysiące(cyfry, i) + wynik;
                                break;
                            }
                        case 5: //dziesiątki tysięcy (10^4)
                            break;  //bo wszystkie czynności w "case 4:"
                        case 6: //setki tysięcy (10^5)
                            break;  //bo wszystkie czynności w "case 4:"
                        case 7: //miliony (10^6)
                            {
                                wynik = this.Trzy_cyfry(cyfry, i) + this.Miliony(cyfry, i) + wynik;
                                break;
                            }
                        case 8: //dziesiątki milionów (10^7)
                            break;  //bo wszystkie czynności w "case 7:"
                        case 9: //setki milionów (10^8)
                            break;  //bo wszystkie czynności w "case 7:"
                        case 10: //miliardy (10^9)
                            {
                                wynik = this.Trzy_cyfry(cyfry, i) + this.Miliardy(cyfry, i) + wynik;
                                break;
                            }
                        case 11: //dziesiątki miliardów (10^10)
                            break;  //bo wszystkie czynności w "case 10:"
                        case 12: //setki miliardów (10^11)
                            break;  //bo wszystkie czynności w "case 10:"
                        default:
                            {
                                MessageBox.Show
                                    (
                                    "Za duża kwota.\n" +
                                    "Max: 999 999 999 999,99",
                                    "BŁĄD #2"
                                    );
                                return;
                            }
                    }

                    //wynik = cyfry[i].ToString() + wynik;
                }
                wynik += " " + cyfry[cyfry.Length-2].ToString() + cyfry[cyfry.Length-1].ToString() + "/100";
                this.Liczebnik_richTextBox.Text = wynik;
                this.Unmark_changes();
            }
            catch (Exception ex)
            {
                this.Liczebnik_richTextBox.Text = "Błąd.";
                this.Mark_changes();
            }
        }   //Przepisz_button_Click

        private string Trzy_cyfry(char[] cyfry_tabl, int min_start_tabl_idx)    //przetwarza trzycyfrową liczbę na liczebnik
        {
            string wynik_tym = "";
            if (min_start_tabl_idx == 0 || cyfry_tabl[min_start_tabl_idx - 1] != '1')
            {
                if (min_start_tabl_idx == 0 || cyfry_tabl[min_start_tabl_idx] != '0')
                {
                    wynik_tym = this.jedności[int.Parse(cyfry_tabl[min_start_tabl_idx].ToString())] + wynik_tym;
                }
            }
            if (min_start_tabl_idx > 0)
            {
                if (cyfry_tabl[min_start_tabl_idx - 1] == '1')
                {
                    wynik_tym = this.naście[int.Parse(cyfry_tabl[min_start_tabl_idx].ToString())] + wynik_tym;
                }
                else if (cyfry_tabl[min_start_tabl_idx - 1] != '0')
                {
                    wynik_tym = this.dziesiątki[int.Parse(cyfry_tabl[min_start_tabl_idx - 1].ToString())] + wynik_tym;
                }
                if (min_start_tabl_idx > 1 && cyfry_tabl[min_start_tabl_idx - 2] != '0')
                {
                    wynik_tym = this.setki[int.Parse(cyfry_tabl[min_start_tabl_idx - 2].ToString())] + wynik_tym;
                }
            }
            return wynik_tym;
        }   //Trzy_cyfry

        private string Tysiące(char[] cyfry_tabl, int min_start_tabl_idx)
        {
            if 
                (
                    (min_start_tabl_idx < 2 || cyfry_tabl[min_start_tabl_idx - 2] == '0') && 
                    (min_start_tabl_idx < 1 || cyfry_tabl[min_start_tabl_idx - 1] == '0') && 
                    cyfry_tabl[min_start_tabl_idx] == '0'
                ) 
                return "";
            if 
                (
                    (min_start_tabl_idx < 2 || cyfry_tabl[min_start_tabl_idx - 2] == '0') &&
                    (min_start_tabl_idx < 1 || cyfry_tabl[min_start_tabl_idx - 1] == '0') && 
                    cyfry_tabl[min_start_tabl_idx] == '1'
                ) 
                return "tysiąc ";
            if (min_start_tabl_idx > 0 && cyfry_tabl[min_start_tabl_idx - 1] == '1') return "tysięcy ";
            if (cyfry_tabl[min_start_tabl_idx] == '2' || cyfry_tabl[min_start_tabl_idx] == '3' || cyfry_tabl[min_start_tabl_idx] == '4')
            {
                return "tysiące ";
            }
            else
            {
                return "tysięcy ";
            }
        }   //Tysiące

        private string Miliony(char[] cyfry_tabl, int min_start_tabl_idx)
        {
            if
                (
                    (min_start_tabl_idx < 2 || cyfry_tabl[min_start_tabl_idx - 2] == '0') &&
                    (min_start_tabl_idx < 1 || cyfry_tabl[min_start_tabl_idx - 1] == '0') &&
                    cyfry_tabl[min_start_tabl_idx] == '0'
                )
                return "";
            if
                (
                    (min_start_tabl_idx < 2 || cyfry_tabl[min_start_tabl_idx - 2] == '0') &&
                    (min_start_tabl_idx < 1 || cyfry_tabl[min_start_tabl_idx - 1] == '0') &&
                    cyfry_tabl[min_start_tabl_idx] == '1'
                )
                return "milion ";
            if (min_start_tabl_idx > 0 && cyfry_tabl[min_start_tabl_idx - 1] == '1') return "milionów ";
            if (cyfry_tabl[min_start_tabl_idx] == '2' || cyfry_tabl[min_start_tabl_idx] == '3' || cyfry_tabl[min_start_tabl_idx] == '4')
            {
                return "miliony ";
            }
            else
            {
                return "milionów ";
            }
        }   //Miliony

        private string Miliardy(char[] cyfry_tabl, int min_start_tabl_idx)
        {
            if
                (
                    (min_start_tabl_idx < 2 || cyfry_tabl[min_start_tabl_idx - 2] == '0') &&
                    (min_start_tabl_idx < 1 || cyfry_tabl[min_start_tabl_idx - 1] == '0') &&
                    cyfry_tabl[min_start_tabl_idx] == '0'
                )
                return "";
            if
                (
                    (min_start_tabl_idx < 2 || cyfry_tabl[min_start_tabl_idx - 2] == '0') &&
                    (min_start_tabl_idx < 1 || cyfry_tabl[min_start_tabl_idx - 1] == '0') &&
                    cyfry_tabl[min_start_tabl_idx] == '1'
                )
                return "miliard ";
            if (min_start_tabl_idx > 0 && cyfry_tabl[min_start_tabl_idx - 1] == '1') return "miliardów ";
            if (cyfry_tabl[min_start_tabl_idx] == '2' || cyfry_tabl[min_start_tabl_idx] == '3' || cyfry_tabl[min_start_tabl_idx] == '4')
            {
                return "miliardy ";
            }
            else
            {
                return "miliardów ";
            }
        }   //Miliardy

        private void About_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show
                (
                "Ten program jest udostępniany w takim stanie, w jakim jest.\n" +
                "Autor nie odpowiada za ewentualne błędne działanie\n" +
                "programu i skutki z tym związane.\n\n\n" +
                "Autor: Piotr Michałowski\n" +
                "piotrm35@hotmail.com\n\n" +
                "rok: 2014\n" +
                "Olsztyn woj. Warmińsko-Mazurskie, Polska\n\n\n" +
                "licencja: GPL v. 2.0",
                "Liczebniki"
                );
        }   //About_button_Click

        private void Mark_changes()
        {
            this.Liczba_textBox.BackColor = Color.LightPink;
            this.Liczebnik_richTextBox.BackColor = Color.LightPink;
        }   //Mark_changes

        private void Unmark_changes()
        {
            this.Liczba_textBox.BackColor = Color.White;
            this.Liczebnik_richTextBox.BackColor = Color.White;
        }

        
    }   //class Liczebniki_Form


}   //namespace Liczebniki
