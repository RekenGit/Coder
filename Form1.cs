using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Form1 : Form
    {
        int Zaznaczony1 = 0;
        int Zaznaczony2 = 0;
        string Binary = "";
        string Inp = "";
        int InpLeng = 0;
        bool stop = false;
        bool upper = true;

        public Form1()
        {
            InitializeComponent();
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox2.SetItemChecked(0, true);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaznaczony1 = checkedListBox1.SelectedIndex;
            int Selected = checkedListBox1.Items.Count;
            for (int x = 0; x < Selected; x++)
            {
                if (Zaznaczony1 != x) checkedListBox1.SetItemChecked(x, false);
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaznaczony2 = checkedListBox2.SelectedIndex;
            int Selected = checkedListBox2.Items.Count;
            for (int x = 0; x < Selected; x++)
            {
                if (Zaznaczony2 != x) checkedListBox2.SetItemChecked(x, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inp = textBox1.Text;
            textBox2.Text = "";
            Binary = "";
            stop = false;
            upper = true;
            string error = "";
            switch (Zaznaczony1) {
                case 0:
                    ToBin();
                    break;
                case 1:
                    error = "0 1 2 3 4 5 6 7";
                    naBinarny(Oct, BCry, error, 8);
                    break;
                case 2:
                    error = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
                    naBinarny(Hex, BHex, error, 16);
                    break;
                case 3:
                    upper = false;
                    error = " A B C D E F G H I J K L M N O P Q R S T U V W X Y Z a b c d e f g h i j k l m n o p q r s t u v w x y z 0 1 2 3 4 5 6 7 8 9 + / ";
                    naBinarny(Tet, BKey, error, 64);
                    break;
                case 4:
                    error = "0 1 2 3 4 5 6 7 8 9 B C D E F G H J K M N P Q R S T U V W X Y Z";
                    naBinarny(Geo, BGeo, error, 32);
                    break;
                case 5:
                    error = "0 1 2 3 4 5 6 7 8 9 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z . , _ ! ? % [ { ( < > ) } ] @ # * / \\ + - = ^ : ; ' \" oraz spcaja";
                    naBinarny(Key, BKey, error, 64);
                    break;
                case 6:
                    error = "` ,  . | ' \" ! -";
                    naBinarny(Cry, BCry, error, 8);
                    break;
                case 7:
                    decBin();
                    break;
            }
            if (!stop){
                switch (Zaznaczony2)
                {
                    case 0:
                        textBox2.Text = Binary;
                        break;
                    case 1:
                        zBinarnego(Oct, BCry, 8, 3);
                        break;
                    case 2:
                        zBinarnego(Hex, BHex, 16, 4);
                        break;
                    case 3:
                        zBinarnego(Tet, BKey, 64, 6);
                        break;
                    case 4:
                        zBinarnego(Geo, BGeo, 32, 5);
                        break;
                    case 5:
                        zBinarnego(Key, BKey, 64, 6);
                        break;
                    case 6:
                        zBinarnego(Cry, BCry, 8, 3);
                        break;
                    case 7:
                        binToDec();
                        break;
                }
            }
        }

        void ToBin()
        {
            bool prawda = false;
            InpLeng = Inp.Length;
            try
            {
                for (int i = 0; i < InpLeng; i++)
                {
                    if ((Inp[i] == '0') || (Inp[i] == '1')) prawda = true;
                    else { prawda = false; break; }
                }
            }
            catch { }
            if (prawda == true) { Binary = Inp; }
            else { textBox2.Text += "Tylko znaki 0 i 1"; stop = true; }
        }

        /* 
            (2) Binarny           - Bin
            (8) Octal             - Oct
            (8) Crypto            - Cry
            (10) Decimal          - Dec
            (16) Hexadecimal      - Hex
            (32) Geohash          - Geo
            (64) KeyBoard         - Key
            (64) Tetrasexagesimal - Tet
        */

        //Biblioteka znaków
        string[] Hex = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "A", "B", "C", "D", "E", "F"};
        string[] BHex = {"0000", "0001", "0010", "0011", "0100", "0101", "0110",
                "0111", "1000", "1001","1010", "1011", "1100", "1101", "1110", "1111"};
        string[] Geo = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "B", "C", "D", "E", "F", "G", "H", "J", "K", "M", "N", "P", "Q",
                "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        string[] BGeo = {"00000", "00001", "00010", "00011", "00100", "00101", "00110",
                "00111", "01000", "01001", "01010", "01011", "01100", "01101", "01110", "01111",
                "10000", "10001", "10010", "10011", "10100", "10101", "10110", "10111", "11000",
                "11001", "11010", "11011", "11100", "11101", "11110", "11111"};
        string[] Key = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9","A", "B", "C",
            "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S",
            "T", "U", "W", "Z", "Q", "V", "X", "Y", ".", ",", "_", "!", "?", "%", "(",
            ")", "[", "]", "{", "}", "<", ">", "@", "#", "/", "\\", "*", "+", "-", "=",
            "^", ":", ";", "\"", "'", " "};
        string[] BKey = {"000000", "000001", "000010", "000011", "000100", "000101", "000110",
                "000111", "001000", "001001","001010", "001011", "001100", "001101", "001110",
                "001111", "010000", "010001", "010010", "010011", "010100", "010101", "010110",
                "010111", "011000", "011001", "011010", "011011", "011100", "011101", "011110",
                "011111", "100000", "100001", "100010", "100011", "100100", "100101", "100110",
                "100111", "101000", "101001", "101010", "101011", "101100", "101101", "101110",
                "101111", "110000", "110001", "110010", "110011", "110100", "110101", "110110",
                "110111", "111000", "111001", "111010", "111011", "111100", "111101", "111110",
                "111111"};
        string[] Cry = {"`", ",", ".", "|", "'", "\"", "!", "-"
        };
        string[] BCry = {"000", "001", "010", "011", "100", "101", "110", "111"
        };
        string[] Oct = { "0", "1", "2", "3", "4", "5", "6", "7"
        };
        string[] Tet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S","T", "U", "V", "W", "X", "Y", "Z", "a", "b",
            "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m","n", "o", "p", "q",
            "r", "s","t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3","4", "5",
            "6", "7", "8", "9", "+", "/"};

        //Podstawy
        void naBinarny(string[] znaki, string[] bin, string error, int ileZnak) {
            InpLeng = Inp.Length;
            string znak;
            for (int i = 0; i < InpLeng; i++) {
                znak = "";
                for (int x = 0; x < ileZnak; x++)
                {
                    if (upper == true) {
                        if (Inp[i].ToString().ToUpper() == znaki[x]) { znak = bin[x]; }
                    }
                    else {
                        if (Inp[i].ToString() == znaki[x]) { znak = bin[x]; }
                    }
                }
                if (znak=="") {textBox2.Text = "Tylko te znaki \""+error+"\"";stop = true;break;}
                Binary += znak;
            }
        }
        void zBinarnego(string[] znaki, string[] bin, int ileZnak, int zera) {
            if(Binary == "0") {
                textBox2.Text = znaki[0];
            } else {
                string RewBin = Binary;
                int BinLeng = Binary.Length;
                string znak = "", calosc = "";
                while (BinLeng > 0)
                {
                    if (BinLeng < zera)
                    {
                        string FirstBit = "";
                        for (int i = 0; i < zera - BinLeng; i++)
                        {
                            FirstBit = "0" + FirstBit;
                        }
                        znak = "";
                        bool usun = true;
                        for (int i = BinLeng; i >= 1; i--)
                        {
                            if (RewBin[BinLeng - i].ToString() == "1") usun = false;
                            znak += RewBin[BinLeng - i];
                        }
                        if (usun == true) { }
                        else
                        {
                            znak = FirstBit + znak;
                            for (int x = 0; x < ileZnak; x++)
                            {
                                if (znak == bin[x]) { znak = znaki[x]; }
                            }
                            calosc = znak + calosc;
                        }
                    }
                    else
                    {
                        znak = "";
                        for (int i = zera; i >= 1; i--)
                        {
                            znak += RewBin[BinLeng - i];
                        }
                        for (int x = 0; x < ileZnak; x++)
                        {
                            if (znak == bin[x]) { znak = znaki[x]; }
                        }
                        calosc = znak + calosc;
                    }
                    BinLeng -= zera;
                }
                textBox2.Text += calosc;
            }
        }
        void decBin() {
            if(Inp.Length <= 10){
                try
                {
                    long liczba = 0;
                    if (Inp == "0")
                    {
                        Binary = "0";
                    }
                    else
                    {
                        liczba = long.Parse(Inp);
                    }
                    while (liczba > 0)
                    {
                        if (liczba % 2 == 0)
                        {
                            liczba /= 2;
                            Binary = 0 + Binary;
                        }
                        else
                        {
                            liczba--;
                            liczba /= 2;
                            Binary = 1 + Binary;
                        }
                    }
                }
                catch { textBox2.Text = "Tylko te znaki \"0 1 2 3 4 5 6 7 8 9\""; stop = true; }
            } else {
                textBox2.Text = "Liczba może mieć maksymalnie 10 znaków, takie są ograniczenia w systemie dziesiętnym"; stop = true;
            }
        }
        void binToDec() {
            long wynik = 0;
            for (int i = 0; i < Binary.Length; i++) {
                if (Binary[i] == '0') {
                    wynik *= 2;
                } else {
                    wynik *= 2;
                    wynik++;
                }
            }
            textBox2.Text = wynik.ToString();
        }
    }
}