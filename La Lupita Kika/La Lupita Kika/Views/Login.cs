using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using La_Lupita_Kika.Views;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using Microsoft.Win32;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace La_Lupita_Kika
{
    public partial class Login : Form
    {
        // Variables for animation
        private const int animationDuration = 500; // Duration of the animation in milliseconds
        private const int animationSteps = 30; // Number of steps in the animation
        private int currentStep = 0;
        private System.Windows.Forms.Timer timer;
        private string connectionString;
        private RolRepository rolRepository;
        private UserRepository.UserRepository userrepo;
        private RegisterRepository registerrepo;
        private int register;
        private DateTime currentDateTime;


        public Login(string connectionString)
        {
            this.connectionString = connectionString;
            this.rolRepository = new RolRepository(connectionString); // Inicializar el repositorio aquí
            this.userrepo = new UserRepository.UserRepository(connectionString);
            this.registerrepo = new RegisterRepository(connectionString);
            this.currentDateTime = DateTime.Now;
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Username_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            String username = Username_textBox.Texts;
            String Password = Pass_textBox.Texts;
            if (username == "" && Password == "")
            {
                MessageBox.Show("Usuario o contraseña vacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Models.User usercomp = userrepo.GetUserByUsername(username);

            if (usercomp == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usercomp.Username == username && usercomp.Password == Password)
            {


                Console.ReadLine();
                // Ocultar el formulario actual
                if (usercomp.Rol_id == 1)
                {
                    this.Hide();

                    // Abrir el nuevo formulario de facturación
                    Home formFacturation = new Home(connectionString);
                    formFacturation.ShowDialog();

                    // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
                    this.Show();
                    return;
                }
                else
                {
                    DateTime currentDateTime = DateTime.Now;
                    Register regis = new Register(currentDateTime, null, null, usercomp.User_id);
                    registerrepo.Add(regis);


                    /*foreach (var register in allRegisters)
                    {
                        Debug.WriteLine(regis.Inhour);
                        Debug.WriteLine($"Register Id: {register.Register_id}, Inhour: {register.Inhour}, Outhour: {register.Outhour}, Daygains: {register.Daygains}, User Id: {register.User_id}");
                    }*/
                    // Redondear la fecha y hora actual a la precisión de segundos
                    // Redondear la fecha y hora de regis.Inhour a la precisión de segundos
                    DateTime roundedInhour = new DateTime(
                        regis.Inhour.Year, regis.Inhour.Month, regis.Inhour.Day,
                        regis.Inhour.Hour, regis.Inhour.Minute, regis.Inhour.Second
                    );
                    Thread.Sleep(1000);
                    List<Register> allRegisters = registerrepo.GetAll();
                    Register foundRegister = allRegisters.Find(register =>
                    {
                        // Redondear la fecha y hora del registro a la precisión de segundos
                        DateTime registerDateTime = new DateTime(
                            register.Inhour.Year, register.Inhour.Month, register.Inhour.Day,
                            register.Inhour.Hour, register.Inhour.Minute, register.Inhour.Second
                        );

                        // Comparar las fechas redondeadas
                        return roundedInhour.Equals(registerDateTime);
                    });


                    this.Hide();
                    if (foundRegister == null)
                    {
                        Login_button_Click(null, EventArgs.Empty);
                    }

                    // Abrir el nuevo formulario de facturación

                    if (foundRegister != null)
                    {
                        Facturation formFacturation = new Facturation(connectionString, foundRegister.Register_id);
                        formFacturation.ShowDialog();
                    }
                }

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {

        }


        private void Login_ResizeEnd(object sender, EventArgs e)
        {

        }


        //animation of closing

        private void pictureBox2_Click(object sender, EventArgs e)
        {


            // initialize the timer for animation
            timer = new System.Windows.Forms.Timer();
            timer.Interval = animationDuration / animationSteps;
            timer.Tick += Timer_Tick;

            // Start the animation
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentStep++;

            // Calculate the opacity for fading (from 1.0 to 0.0)
            double opacity = 1 - (double)currentStep / animationSteps;
            this.Opacity = opacity;

            // When the last step of the animation is reached, close the form
            if (currentStep == animationSteps)
            {
                timer.Stop();
                this.Close();
            }
        }

        private void Pass_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si se ha presionado la tecla Enter (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al evento Login_button_Click
                Login_button_Click(sender, e);
            }
        }

        private void Pass_textBox__TextChanged(object sender, EventArgs e)
        {

        }
    }
}