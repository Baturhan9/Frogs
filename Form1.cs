using DevExpress.Utils.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogsssss
{
    
    public partial class Form1 : Form
    {
        bool isRight = false;
        int indexMove = -1;

        char[] map = { '*', '*','*','-','#','#','#' };
        Point[] locationp = new Point[7];
        PictureBox[] frogsPicture = new PictureBox[7];
        public Form1()
        {
            InitializeComponent();
            locationp[0] = RightFrog1.Location;
            locationp[1] = RightFrog2.Location;
            locationp[2] = RightFrog3.Location;
            locationp[3] = pictureVoid.Location;
            locationp[4] = LeftFrog1.Location;
            locationp[5] = LeftFrog2.Location;
            locationp[6] = LeftFrog3.Location;

            frogsPicture[0] = RightFrog1;
            frogsPicture[1] = RightFrog2;
            frogsPicture[2] = RightFrog3;
            frogsPicture[3] = pictureVoid;
            frogsPicture[4] = LeftFrog1;
            frogsPicture[5] = LeftFrog2;
            frogsPicture[6] = LeftFrog3;

        }

        private bool CanJump (int index)
        {
            if (isRight && (map[index + 1] == '-' || map[index + 2] == '-'))
                return true;
            else if (!isRight && (map[index - 1] == '-' || map[index- 2] == '-'))
                return true;
            return false;
        }

        private int FindIndexFrogs(PictureBox pb)
        {
            for(int i = 0; i < frogsPicture.Length; i++)
            {
                if(frogsPicture[i] == pb)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindIndexSpace()
        {
            for (int i = 0; i < frogsPicture.Length; i++)
            {
                if (frogsPicture[i] == pictureVoid)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Swamp (int indexfrogs, int indexspace)
        {
            PictureBox temp = frogsPicture[indexfrogs];
            frogsPicture[indexfrogs] = frogsPicture[indexspace];
            frogsPicture[indexspace] = temp;

            char ctemp = map[indexfrogs];
            map[indexfrogs] = map[indexspace];
            map[indexspace] = ctemp;

            frogsPicture[indexspace].Location = locationp[indexspace];
            frogsPicture[indexfrogs].Location = locationp[indexfrogs];

            
        }

        private void RightFrog1_Click(object sender, EventArgs e)
        {
            isRight = true;
            indexMove = FindIndexFrogs(RightFrog1);
        }

        private void RightFrog2_Click(object sender, EventArgs e)
        {
            isRight = true;
            indexMove = FindIndexFrogs(RightFrog2);
        }

        private void RightFrog3_Click(object sender, EventArgs e)
        {
            isRight= true;
            indexMove = FindIndexFrogs(RightFrog3);
        }

        private void LeftFrog1_Click(object sender, EventArgs e)
        {
            isRight = false;
            indexMove = FindIndexFrogs(LeftFrog1);
        }

        private void LeftFrog2_Click(object sender, EventArgs e)
        {
            isRight = false;
            indexMove = FindIndexFrogs(LeftFrog2);
        }

        private void LeftFrog3_Click(object sender, EventArgs e)
        {
            isRight = false;
            indexMove = FindIndexFrogs(LeftFrog3);
        }

        private void BtnNextMove_Click(object sender, EventArgs e)
        {
            if (indexMove != -1 && CanJump(indexMove))
            {
                Swamp(indexMove, FindIndexSpace());
                indexMove = -1;
            }
            else
            {
                MessageBox.Show("Невозможно сделать ход");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frogsPicture[0] = RightFrog1;
            frogsPicture[1] = RightFrog2;
            frogsPicture[2] = RightFrog3;
            frogsPicture[3] = pictureVoid;
            frogsPicture[4] = LeftFrog1;
            frogsPicture[5] = LeftFrog2;
            frogsPicture[6] = LeftFrog3;

            for(int i = 0; i < frogsPicture.Length; i++)
                frogsPicture[i].Location = locationp[i];
        }
    }
}
