using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsLab
{
    public partial class Form1 : Form
    {
        public float d;
        public int Xo;
        public int Yo;
        public Graphics graphic;
        public double c = 0;
        public double[] center;

        Hat hat;
        Head head;
        Clothes clothes;
        Body body;

        public Form1()
        {
            InitializeComponent();
            graphic = CreateGraphics();
            Width = 800;
            Height = 450;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                    d = 7;
                    if (hat != null)
                    {
                        hat.Dispose();
                        head.Dispose();
                        clothes.Dispose();
                        body.Dispose();
                    }
                    Yo = (int)d*15;
                    Xo = (int)d*15;
                    center =new double[] { Xo, Yo };

                    hat = new Hat(graphic, d, Xo, Yo);
                    head = new Head(graphic, d, Xo, Yo);
                    clothes = new Clothes(graphic, d, Xo, Yo);
                    body = new Body(graphic, d, Xo, Yo);
                    break;

                case Keys.C:
                    graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                    if (hat != null)
                    {
                        hat.Dispose();
                        head.Dispose();
                        clothes.Dispose();
                        body.Dispose();
                    }
                    break;

                case Keys.Left:
                    if (hat != null)
                    {
                        graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                        /* for (int i = 0; i < (hat.HatMatrix.Length / 2); i++) { hat.HatMatrix[i, 0]-=d; }
                         for (int i = 0; i < head.Matrix.Length / 2; i++) { head.Matrix[i, 0] -= d; }
                         for (int i = 0; i < clothes.shirtMatrix.Length / 2; i++) { clothes.shirtMatrix[i, 0] -= d; }
                         for (int i = 0; i < clothes.overallsMatrix.Length / 2; i++) { clothes.overallsMatrix[i, 0] -= d; }
                         for (int i = 0; i < clothes.shoesMatrix.Length / 2; i++) { clothes.shoesMatrix[i, 0] -= d; }
                         for (int i = 0; i < body.SkinMatrix.Length / 2; i++) { body.SkinMatrix[i, 0] -= d; }
                         */

                        double[,] Tmatr = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -1, 0, 1 } };

                        hat.Trans(Tmatr);
                        head.Trans(Tmatr);
                        clothes.Trans(Tmatr);
                        body.Trans(Tmatr);

                        hat.Redraw(d);
                        head.Redraw(d);
                        clothes.Redraw(d);
                        body.Redraw(d);

                    }
                    break;

                case Keys.Right:
                    if (hat != null)
                    {
                        graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                        /*for (int i = 0; i < (hat.HatMatrix.Length / 2); i++) { hat.HatMatrix[i, 0]+=d; }
                        for (int i = 0; i < head.Matrix.Length / 2; i++) { head.Matrix[i, 0] += d; }
                        for (int i = 0; i < clothes.shirtMatrix.Length / 2; i++) { clothes.shirtMatrix[i, 0] += d; }
                        for (int i = 0; i < clothes.overallsMatrix.Length /2; i++) { clothes.overallsMatrix[i, 0] += d; }
                        for (int i = 0; i < clothes.shoesMatrix.Length / 2; i++) { clothes.shoesMatrix[i, 0] += d; }
                        for (int i = 0; i < body.SkinMatrix.Length /2; i++) { body.SkinMatrix[i, 0] += d; }
                        */
                        double[,] Tmatr = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 1, 0, 1 } };

                        hat.Trans(Tmatr);
                        head.Trans(Tmatr);
                        clothes.Trans(Tmatr);
                        body.Trans(Tmatr);

                        hat.Redraw(d);
                        head.Redraw(d);
                        clothes.Redraw(d);
                        body.Redraw(d);

                    }
                    break;

                case Keys.Up:
                    if (hat != null)
                    {
                        graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                        /*for (int i = 0; i < (hat.HatMatrix.Length / 2); i++) { hat.HatMatrix[i, 1]+=1; }
                        for (int i = 0; i < head.Matrix.Length / 2; i++) { head.Matrix[i, 1] += 1; }
                        for (int i = 0; i < clothes.shirtMatrix.Length / 2; i++) { clothes.shirtMatrix[i, 1] += 1; }
                        for (int i = 0; i < clothes.overallsMatrix.Length /2; i++) { clothes.overallsMatrix[i, 1] += 1; }
                        for (int i = 0; i < clothes.shoesMatrix.Length / 2; i++) { clothes.shoesMatrix[i, 1] += 1; }
                        for (int i = 0; i < body.SkinMatrix.Length / 2; i++) { body.SkinMatrix[i, 1] += 1; }
                        */
                        double[,] Tmatr = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 1, 1 } };

                        hat.Trans(Tmatr);
                        head.Trans(Tmatr);
                        clothes.Trans(Tmatr);
                        body.Trans(Tmatr);

                        hat.Redraw(d);
                        head.Redraw(d);
                        clothes.Redraw(d);
                        body.Redraw(d);
                    }
                    break;

                case Keys.Down:
                    if (hat != null)
                    {
                        graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                        /*for (int i = 0; i < (hat.HatMatrix.Length / 2); i++) { hat.HatMatrix[i, 1]-=1; }
                        for (int i = 0; i < head.Matrix.Length / 2; i++) { head.Matrix[i, 1] -= 1; }
                        for (int i = 0; i < clothes.shirtMatrix.Length / 2; i++) { clothes.shirtMatrix[i, 1] -= 1; }
                        for (int i = 0; i < clothes.overallsMatrix.Length / 2; i++) { clothes.overallsMatrix[i, 1] -= 1; }
                        for (int i = 0; i < clothes.shoesMatrix.Length / 2; i++) { clothes.shoesMatrix[i, 1] -=1 ; }
                        for (int i = 0; i < body.SkinMatrix.Length / 2; i++) { body.SkinMatrix[i, 1] -= 1; }*/
                        double[,] Tmatr = new double[,] { { 1, 0,0}, {0, 1,0 },{0,-1,1 } };

                        hat.Trans(Tmatr);
                        head.Trans(Tmatr);
                        clothes.Trans(Tmatr);
                        body.Trans(Tmatr);

                        hat.Redraw(d);
                        head.Redraw(d);
                        clothes.Redraw(d);
                        body.Redraw(d);
                    }
                    break;

                case Keys.Oemplus:
                    if (hat != null)
                    {
                        d++;
                        graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                        hat.Redraw(d);
                        head.Redraw(d);
                        clothes.Redraw(d);
                        body.Redraw(d);
                    }
                    break;

                case Keys.OemMinus:
                    if (hat != null)
                    {
                        d--;
                        /*
                        double[,] MMatr = new double[,] { {d,0,0 },{0,d,0 },{ 0,0,1} };

                        hat.Mash(MMatr);
                        head.Trans(MMatr);
                        clothes.Trans(MMatr);
                        body.Trans(MMatr);*/

                        graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                        hat.Redraw(d);
                        head.Redraw(d);
                        clothes.Redraw(d);
                        body.Redraw(d);
                    }
                    break;

                case Keys.Q:
                    if (hat != null)
                    {/*
                        hat.Xo = (int)center[0];
                        hat.Yo = (int)center[1];
                        head.Xo = (int)center[0];
                        head.Yo = (int)center[1];
                        clothes.Xo = (int)center[0];
                        clothes.Yo = (int)center[1];
                        body.Xo = (int)center[0];
                        body.Yo = (int)center[1];
                        */
                        double[,] transM = new double[,] { {  0, 1, 0},  { -1, 0,0 },{0,0,1 } };
                        graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                        hat.Trans(transM);
                        head.Trans(transM);
                        clothes.Trans(transM);
                        body.Trans(transM);

                        hat.Redraw(d);
                        head.Redraw(d);
                        clothes.Redraw(d);
                        body.Redraw(d);
                    }
                    break;

                case Keys.E:
                    if (hat != null)
                    {
                        double[,] transM = new double[,] { {  0, -1,0  },  { 1, 0,0},{ 0,0,1} };
                        graphic.FillRectangle(Brushes.White, 0, 0, Width, Height);
                        hat.Trans(transM);
                        head.Trans(transM);
                        clothes.Trans(transM);
                        body.Trans(transM);

                        hat.Redraw(d);
                        head.Redraw(d);
                        clothes.Redraw(d);
                        body.Redraw(d);
                    }
                    break;

                default:
                    break;
            }
        }
    }

    public class Hat : IDisposable
    {
        public int Xo;
        public int Yo;
        Graphics g;
        public double[,] HatMatrix;

        float dd;

        private double GenerateXw(double x, float d)
        {
            int GetX = SystemInformation.PrimaryMonitorSize.Width;
            return Xo+ (x) * d;
        }

        private double GenerateYw(double y, float d)
        {
            int GetY = SystemInformation.PrimaryMonitorSize.Height;
            return Yo -( y) * d;
        }

        public Hat(Graphics graphic, float d, int X, int Y)
        {
            dd = d;
            g = graphic;
            Xo = X;
            Yo = Y;

            //крассная кепка
            HatMatrix = new double[,] { { -3, 8,1 },{ -2,8,1},{ -1,8,1},{ 0,8,1},{ 1,8,1},
                {-4,7,1 },{-3,7,1 },{-2,7,1 },{-1,7,1 },{0,7,1 },{1,7,1 },{2,7,1 },{3,7,1 },{4,7,1 } };

            for (int i = 0; i <= (HatMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(HatMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(HatMatrix[i, 1], d);

                g.FillRectangle(Brushes.Red, pointX1, pointY1, d, d);
            }
        }

        public void Mash(double[,] TMatr)
        {
            double[,] newM = new double[HatMatrix.GetLength(0), TMatr.GetLength(0)];

            for (int i = 0; i < HatMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < TMatr.GetLength(1); j++)
                {
                    for (int k = 0; k < TMatr.GetLength(0); k++)
                    {
                        newM[i, j] += HatMatrix[i, k] * TMatr[k, j];
                    }
                }
            }
            HatMatrix = newM;
        }

        public void Trans(double[,] TMatr)
        {
            double[,] newM = new double[HatMatrix.GetLength(0), TMatr.GetLength(0)];

            for (int i = 0; i < HatMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < TMatr.GetLength(1); j++)
                {
                    for (int k = 0; k < TMatr.GetLength(0); k++)
                    {
                        newM[i, j] += HatMatrix[i, k] * TMatr[k, j];
                    }
                }
            }
            HatMatrix = newM;
        }

        public void Redraw(float d)
        {
            dd = d;

            //красная кепка
            for (int i = 0; i <= (HatMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(HatMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(HatMatrix[i, 1], d);

                g.FillRectangle(Brushes.Red, pointX1, pointY1, d, d);
            }
        }

        public void Turn(double[,] transM)
        {

            double[,] newM = new double[HatMatrix.GetLength(0), transM.GetLength(1)];

            for (int i = 0; i < HatMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < transM.GetLength(1); j++)
                {
                    for (int k = 0; k < transM.GetLength(0); k++)
                    {
                        newM[i, j] += HatMatrix[i, k] * transM[k, j];
                    }
                }
            }

            HatMatrix = newM;
        }

        public void Dispose()
        {

        }
    }

    public class Body : IDisposable
    {
        public int Xo;
        public int Yo;

        Graphics g;
        public double[,] SkinMatrix;
        //public double[,] BorderMatrix;
        float dd;

        private double GenerateXw(double x, float d)
        {
            int GetX = SystemInformation.PrimaryMonitorSize.Width;
            return Xo + (x) * d;
        }

        private double GenerateYw(double y, float d)
        {
            int GetY = SystemInformation.PrimaryMonitorSize.Height;
            return Yo - (y) * d;
        }

        public Body(Graphics graphic, float d, int X, int Y)
        {
            dd = d;
            g = graphic;
            Xo = X;
            Yo = Y;

            //кожа
            /*
            SkinMatrix = new double[,] { {  -1, 6 } , { 0, 6 }  ,{ 2,6 }  ,
                { -4,5} ,{  -2,5} ,{ -1,5 },{ 0,5} ,{ 2,5},{ 3,5 } ,{4,5} ,
                { -4,4}  ,{ -1,4} ,{0,4}  ,{1,4} ,{ 3,4} ,{4,4 },{5,4} ,
                {-3,3 },{ -2,3},{ -1,3},{ 0,3},
                { -3,2} ,{ -2,2},{ -1,2},{ 0,2} ,{ 1,2} ,{2,2} ,{3,2},
                { -6,-2} ,{ -5,-2},{ -2,-2},{ 1,-2},{4,-2} ,{5,-2},
                {-6,-3} ,{-5,-3},{ -4,-3},{3,-3},{4,-3}  ,{5,-3,},
                {-6,-4},{ -5,-4},{ 4,-4} ,{ 5,-4} };
            */
              SkinMatrix = new double[,] { {  -1, 6, 1 } , { 0, 6, 1 }  ,{ 2,6,1 }  ,
                { -4,5,1 } ,{  -2,5,1  } ,{ -1,5,1  },{ 0,5,1  } ,{ 2,5,1},{ 3,5,1 } ,{4,5 ,1  } ,
                { -4,4,1 }  ,{ -1,4,1 } ,{0,4,1 }  ,{1,4,1  } ,{ 3,4,1  } ,{4,4,1  },{5,4,1  } ,
                {-3,3,1 },{ -2,3,1},{ -1,3,1  },{ 0,3,1  } ,
                { -3,2,1} ,{ -2,2,1  },{ -1,2,1},{ 0,2,1 } ,{ 1,2,1} ,{2,2,1 } ,{3,2,1},
                { -6,-2,1} ,{ -5,-2,1 },{ -2,-2,1 },{ 1,-2,1},{4,-2,1 } ,{5,-2,1},
                {-6,-3,1 } ,{-5,-3,1  },{ -4,-3,1 },{3,-3,1 },{4,-3,1 }  ,{5,-3,1 },
                {-6,-4,1 },{ -5,-4,1 },{ 4,-4,1 } ,{ 5,-4,1  } };
                

            for (int i = 0; i <= (SkinMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(SkinMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(SkinMatrix[i, 1], d);

                g.FillRectangle(Brushes.Yellow, pointX1, pointY1, d, d);
            }
        }

        public void Mash(double[,] TMatr)
        {
            double[,] newM = new double[SkinMatrix.GetLength(0), TMatr.GetLength(0)];

            for (int i = 0; i < SkinMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < TMatr.GetLength(1); j++)
                {
                    for (int k = 0; k < TMatr.GetLength(0); k++)
                    {
                        newM[i, j] += SkinMatrix[i, k] * TMatr[k, j];
                    }
                }
            }
            SkinMatrix = newM;
        }

        public void Trans(double[,] TMatr)
        {
            double[,] newM = new double[SkinMatrix.GetLength(0), TMatr.GetLength(0)];

            for (int i = 0; i < SkinMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < TMatr.GetLength(1); j++)
                {
                    for (int k = 0; k < TMatr.GetLength(0); k++)
                    {
                        newM[i, j] += SkinMatrix[i, k] * TMatr[k, j];
                    }
                }
            }
            SkinMatrix = newM;
        }

        public void Turn(double[,] transM)
        {

            double[,] newM = new double[SkinMatrix.GetLength(0), transM.GetLength(1)];

            for (int i = 0; i < SkinMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < transM.GetLength(1); j++)
                {
                    for (int k = 0; k < transM.GetLength(0); k++)
                    {
                        newM[i, j] += SkinMatrix[i, k] * transM[k, j];
                    }
                }
            }
            SkinMatrix = newM;
        }

        public void Redraw(float d)
        {
            dd = d;

            //кожа
            for (int i = 0; i <= (SkinMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(SkinMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(SkinMatrix[i, 1], d);

                g.FillRectangle(Brushes.Yellow, pointX1, pointY1, d, d);
            }            
        }

        public void Dispose()
        {

        }
    }

    public class Head : IDisposable
    {
        public int Xo;
        public int Yo;
        Graphics g;
        public double[,] Matrix;
        public float dd;

        private double GenerateXw(double x, float d)
        {
            int GetX = SystemInformation.PrimaryMonitorSize.Width;
            return Xo + (x) * d;
        }

        private double GenerateYw(double y, float d)
        {
            int GetY = SystemInformation.PrimaryMonitorSize.Height;
            return Yo - (y) * d;
        }

        public Head(Graphics graphic, float d, int X, int Y)
        {
            dd = d;
            g = graphic;
            Xo = X;
            Yo = Y;

            //лицо
            Matrix = new double[,] { { -4, 6,1 },{ -3, 6,1 },{ -2, 6,1 },  { -3, 5 ,1},
                { -3, 4,1 }, { -2, 4,1 }, { -4,3,1 }, {-5,3,1 },{ -5,4,1 },{ -5,5,1},
                { 1, 6,1 }, { 1, 5,1 }, { 2, 4,1 }, { 2, 3,1 },
                { 1, 3,1 }, { 3, 3,1 }, { 4, 3,1 }};


            for (int i = 0; i <= (Matrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(Matrix[i, 0], d);
                float pointY1 = (float)GenerateYw(Matrix[i, 1], d);

                g.FillRectangle(Brushes.Brown, pointX1, pointY1, d, d);
            }
        }

        public void Mash(double[,] TMatr)
        {
            double[,] newM = new double[Matrix.GetLength(0), TMatr.GetLength(0)];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < TMatr.GetLength(1); j++)
                {
                    for (int k = 0; k < TMatr.GetLength(0); k++)
                    {
                        newM[i, j] += Matrix[i, k] * TMatr[k, j];
                    }
                }
            }
            Matrix = newM;
        }

        public void Redraw(float d)
        {
            dd = d;

            //лицо
            for (int i = 0; i <= (Matrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(Matrix[i, 0], d);
                float pointY1 = (float)GenerateYw(Matrix[i, 1], d);

                g.FillRectangle(Brushes.Brown, pointX1, pointY1, d, d);
            }
        }

        public void Trans(double[,] TMatr)
        {
            double[,] newM = new double[Matrix.GetLength(0), TMatr.GetLength(0)];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < TMatr.GetLength(1); j++)
                {
                    for (int k = 0; k < TMatr.GetLength(0); k++)
                    {
                        newM[i, j] += Matrix[i, k] * TMatr[k, j];
                    }
                }
            }
            Matrix = newM;
        }

        public void Turn(double[,] transM)
        {
            double[,] newM = new double[Matrix.GetLength(0), transM.GetLength(1)];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < transM.GetLength(1); j++)
                {
                    for (int k = 0; k < transM.GetLength(0); k++)
                    {
                        newM[i, j] += Matrix[i, k] * transM[k, j];
                    }
                }
            }

            Matrix = newM;
        }
        public void Dispose()
        {

        }
    }

    public class Clothes : IDisposable
    {
        public int Xo;
        public int Yo;
        Graphics g;

        public double[,] shirtMatrix;
        public double[,] overallsMatrix;
        public double[,] shoesMatrix;
        float dd;

        private double GenerateXw(double x, float d)
        {
            int GetX = SystemInformation.PrimaryMonitorSize.Width;
            return Xo + (x) * d;
        }

        private double GenerateYw(double y, float d)
        {
            int GetY = SystemInformation.PrimaryMonitorSize.Height;
            return Yo - (y) * d;
        }

        public Clothes(Graphics graphic, float d, int X, int Y)
        {
            dd = d;
            g = graphic;
            Xo = X;
            Yo = Y;

            //коричневая часть рубашки
            /*shirtMatrix = new double[,] { { -4, 1},{ -3, 1 },{ -1,1},{ 0,1},{ 1,1},
                { -5,0 },{ -4,0},{ -3,0},{ -1,0},{ 0,0},{2,0 },{ 3,0},{ 4,0},
                { -6,-1},{ -5,-1},{ -4,-1},{ -3,-1},{ -1,-1},{ 0,-1},{2,-1},{ 3,-1},{ 4,-1},{5,-1},
                { -4,-2},{ 3,-2} };
            */
             shirtMatrix = new double[,] { { -4, 1 ,1},{ -3, 1,1 },{ -1,1,1},{ 0,1,1},{ 1,1,1},
                { -5,0,1},{ -4,0,1},{ -3,0,1},{ -1,0,1},{ 0,0,1},{2,0 ,1},{ 3,0,1},{ 4,0,1},
                { -6,-1,1},{ -5,-1,1},{ -4,-1,1},{ -3,-1,1},{ -1,-1,1},{ 0,-1,1},{2,-1,1 },{ 3,-1,1},{ 4,-1,1},{5,-1 ,1},
                { -4,-2,1},{ 3,-2,1} };
                

            for (int i = 0; i <= (shirtMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(shirtMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(shirtMatrix[i, 1], d);

                g.FillRectangle(Brushes.Brown, pointX1, pointY1, d, d);
            }

            //крассный комбез
            /*overallsMatrix = new double[,] { { -2,1},{ -2,0},{ -2,-1},{ -1,-1},{ 0,-1},{ 1,-1},{ 1,0},
                { -3,-2},{-1,-2},{0,-2},{2,-2},
                {-3,-3},{-2,-3},{-1,-3 },{0,-3},{ 1,-3},{2,-3},
                {-4,-4 },{-3,-4 },{-2,-4},{-1,-4},{0,-4},{ 1,-4},{2,-4},{3,-4},
                { -4,-5},{ -3,-5},{ -2,-5},{ 1,-5},{ 2,-5},{ 3,-5} };
            */overallsMatrix = new double[,] { { -2,1,1},{ -2,0,1},{ -2,-1,1},{ -1,-1,1},{ 0,-1,1},{ 1,-1,1},{ 1,0,1},
                { -3,-2,1},{-1,-2 ,1},{0,-2 ,1},{2,-2,1 },
                {-3,-3 ,1},{-2,-3 ,1},{-1,-3 ,1},{0,-3 ,1},{ 1,-3,1},{2,-3,1 },
                {-4,-4 ,1},{-3,-4,1 },{-2,-4 ,1},{-1,-4 ,1},{0,-4 ,1},{ 1,-4,1},{2,-4,1 },{3,-4,1 },
                { -4,-5,1},{ -3,-5,1},{ -2,-5,1},{ 1,-5,1},{ 2,-5,1},{ 3,-5,1} };

            for (int i = 0; i <= (overallsMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(overallsMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(overallsMatrix[i, 1], d);

                g.FillRectangle(Brushes.Red, pointX1, pointY1, d, d);
            }

            //коричневая обувь
            /*shoesMatrix = new double[,] { { -5,-6},{ -4,-6},{ -3,-6},{ 2,-6},{ 3,-6},{ 4,-6},
                { -6,-7},{ -5,-7},{ -4,-7},{ -3,-7},{ 2,-7},{3,-7},{ 4,-7},{ 5,-7} };
            */
            shoesMatrix = new double[,] { { -5,-6,1},{ -4,-6,1},{ -3,-6,1},{ 2,-6,1},{ 3,-6,1},{ 4,-6,1},
                { -6,-7,1},{ -5,-7,1},{ -4,-7,1},{ -3,-7,1},{ 2,-7,1},{3,-7,1 },{ 4,-7,1},{ 5,-7,1} };

            for (int i = 0; i <= (shoesMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(shoesMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(shoesMatrix[i, 1], d);

                g.FillRectangle(Brushes.Brown, pointX1, pointY1, d, d);
            }

        }

        public void Trans(double[,] TMatr)
        {
            //рубашка
            double[,] newM = new double[shirtMatrix.GetLength(0), TMatr.GetLength(0)];

            for (int i = 0; i < shirtMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < TMatr.GetLength(1); j++)
                {
                    for (int k = 0; k < TMatr.GetLength(0); k++)
                    {
                        newM[i, j] += shirtMatrix[i, k] * TMatr[k, j];
                    }
                }
            }
            shirtMatrix = newM;

            //комбез
            double[,] newnewM = new double[overallsMatrix.GetLength(0), TMatr.GetLength(0)];

            for (int i = 0; i < overallsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < TMatr.GetLength(1); j++)
                {
                    for (int k = 0; k < TMatr.GetLength(0); k++)
                    {
                        newnewM[i, j] += overallsMatrix[i, k] * TMatr[k, j];
                    }
                }
            }
            overallsMatrix = newnewM;

            //обувь
            double[,] newnewnewM = new double[shoesMatrix.GetLength(0), TMatr.GetLength(0)];

            for (int i = 0; i < shoesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < TMatr.GetLength(1); j++)
                {
                    for (int k = 0; k < TMatr.GetLength(0); k++)
                    {
                        newnewnewM[i, j] += shoesMatrix[i, k] * TMatr[k, j];
                    }
                }
            }
            shoesMatrix = newnewnewM;
        }

        public void Redraw(float d)
        {
            dd = d;

            //коричневая часть рубашки

            for (int i = 0; i <= (shirtMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(shirtMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(shirtMatrix[i, 1], d);

                g.FillRectangle(Brushes.Brown, pointX1, pointY1, d, d);
            }

            //крассный комбез
            for (int i = 0; i <= (overallsMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(overallsMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(overallsMatrix[i, 1], d);

                g.FillRectangle(Brushes.Red, pointX1, pointY1, d, d);
            }

            //коричневая обувь
            for (int i = 0; i <= (shoesMatrix.Length / 3) - 1; i++)
            {
                float pointX1 = (float)GenerateXw(shoesMatrix[i, 0], d);
                float pointY1 = (float)GenerateYw(shoesMatrix[i, 1], d);

                g.FillRectangle(Brushes.Brown, pointX1, pointY1, d, d);
            }
        }

        public void Turn(double[,] transM)
        {
            double[,] newM = new double[shirtMatrix.GetLength(0), transM.GetLength(1)];

            for (int i = 0; i < shirtMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < transM.GetLength(1); j++)
                {
                    for (int k = 0; k < transM.GetLength(0); k++)
                    {
                        newM[i, j] += shirtMatrix[i, k] * transM[k, j];
                    }
                }
            }
            shirtMatrix = newM;

            double[,] newnewM = new double[overallsMatrix.GetLength(0), transM.GetLength(1)];

            for (int i = 0; i < overallsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < transM.GetLength(1); j++)
                {
                    for (int k = 0; k < transM.GetLength(0); k++)
                    {
                        newnewM[i, j] += overallsMatrix[i, k] * transM[k, j];
                    }
                }
            }
            overallsMatrix = newnewM;

            double[,] newnewnewM = new double[shoesMatrix.GetLength(0), transM.GetLength(1)];

            for (int i = 0; i < shoesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < transM.GetLength(1); j++)
                {
                    for (int k = 0; k < transM.GetLength(0); k++)
                    {
                        newnewnewM[i, j] += shoesMatrix[i, k] * transM[k, j];
                    }
                }
            }
            shoesMatrix = newnewnewM;
        }

        public void Dispose()
        {

        }
    }
}
