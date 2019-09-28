using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sayinin_karekokunu_bulma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string karekok(int a)
        {
            
                int sayi = a;
                //ArrayList dizi = new ArrayList();
                List<int> dizi = new List<int>();
                for (int i = 2; i <= sayi; )//bölündüğü sayıları bulmak için 
                {
                    if (sayi % i == 0)
                    {
                        sayi = sayi / i;
                        dizi.Add(i);
                        i = 2;
                        if (sayi < 2)
                        {

                            break;
                        }
                        if (sayi == 2)
                        {
                            dizi.Add(2);
                            break;
                        }
                    }
                    else
                        i++;
                }

                int dis = 1, ic = 1, sayac = 0;
                for (int j = 2; j <= a; j++)
                {
                    for (int i = 0; i < dizi.Count/*dizideki eleman sayısı*/; i++)
                    {
                        if (j == dizi[i])
                        {
                            sayac++;
                            if (sayac == 2)
                            {
                                dis = dis * j;
                                sayac = 0;
                            }
                        }
                    }
                    if (sayac == 1)
                    {
                        ic *= j;
                        sayac = 0;
                    }
                }
                if (dis > 1 && ic > 1)
                    return dis.ToString() + "√" + ic.ToString();
                else if (dis == 1)
                    return "√" + ic.ToString();
                else
                    return dis.ToString();
       
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
   /*       
     textBox2.Text = int.Parse(textBox1.Text) < 0 ? "NEGATİF SAYILAR KULLANILAMAZ" : karekok(int.Parse(textBox1.Text));           
  */
            try
            {
                textBox2.Clear();
                textBox3.Clear();
                if (textBox1.Text != "" || textBox1.Text.IndexOf("-") != -1)
                {
                    string b = textBox1.Text;
                    int index = b.IndexOf("√");
                    if (index == 0)
                    {
                        b = b.Remove(index, 1);
                        textBox3.Text = textBox1.Text;
                        textBox2.Text = karekok(int.Parse(b));

                    }
                    else if (index > 0)
                    {
                        int a1 = int.Parse(b.Substring(0, index));
                        int a2 = int.Parse(b.Substring(index + 1));
                        int a3 = a1 * a1 * a2;
                        textBox3.Text = "√" + a3.ToString();
                        textBox2.Text = karekok(a3);
                    }
                    else if (index == -1)
                    {
                        textBox3.Text = "√" + (int.Parse(b) * int.Parse(b)).ToString();
                        textBox2.Text = karekok(int.Parse(b) * int.Parse(b));
                    }
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "√";
        }
    }
}
