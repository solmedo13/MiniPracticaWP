using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MiniPracticaWP.Resources;
using System.Threading;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace MiniPracticaWP
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Storyboard guion;
        // Constructor
        public MainPage()
        {
            guion = new Storyboard();
            InitializeComponent();


            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        
        private void desorganizar(object sender, RoutedEventArgs e)
        {
            if (object.ReferenceEquals(sender, botonMover))
            {
                botonMover.IsEnabled = false;
                if (this.guion.Children.Count > 0)
                {
                    this.guion.Stop();
                    this.guion.Children.Clear();

                }

                guion.Completed += new EventHandler(guionCompleted);
                this.desaparecer();
                this.intercambio();
                this.guion.Begin();
                
            }
        }

        private void guionCompleted(object sender, EventArgs e)
        {
            botonMover.IsEnabled = true;
        }

        private void intercambio()
        {
            this.moverNombre();
            this.moverAsignatura();
           
        }

        private void moverAsignatura()
        {

            DoubleAnimation anima = new DoubleAnimation();
            Storyboard.SetTarget(anima, asignatura);
            Storyboard.SetTargetProperty(anima, new PropertyPath(Canvas.TopProperty));
           
            
                anima.From = 389;
                anima.To = 309;
          
            anima.Duration = new Duration(new TimeSpan(0, 0, 10));
            guion.Children.Add(anima);

            anima = new DoubleAnimation();
            Storyboard.SetTarget(anima, asignaturaRotation);
            Storyboard.SetTargetProperty(anima, new PropertyPath(RotateTransform.AngleProperty));

            anima.To = 360;

            anima.Duration = new Duration(new TimeSpan(0, 0, 10));
            guion.Children.Add(anima);
        }
        
        private Color getColor(String nombreColor) {
            Color color = new Color();
            switch (nombreColor) {
                case "azul":
                    
                    color.A = 1;
                    color.R = 142;
                    color.G = 185;
                    color.B = 247;
                    break;
                case "blanco":
                  
                    color.A = 1;
                    color.R = 255;
                    color.G = 255;
                    color.B = 255;
                    break;

            }
            return color;
        }
        
        private void moverNombre()
        {



            /*ColorAnimation colorAnimation = new ColorAnimation();
            Storyboard.SetTarget(colorAnimation, alumno);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));
            colorAnimation.To = Colors.Yellow ;
            colorAnimation.Duration = new Duration(new TimeSpan(0, 0, 10));
            guion.Children.Add(colorAnimation);
           */


            DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();
            EasingDoubleKeyFrame easyDoubleKeyFrame = new EasingDoubleKeyFrame();
            Storyboard.SetTarget(animation, alumno);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));

            easyDoubleKeyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 5));
            easyDoubleKeyFrame.Value = 0;
            animation.KeyFrames.Add(easyDoubleKeyFrame);
            easyDoubleKeyFrame = new EasingDoubleKeyFrame();
            easyDoubleKeyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 10));
            easyDoubleKeyFrame.Value = 52;
            animation.KeyFrames.Add(easyDoubleKeyFrame);
            
            guion.Children.Add(animation);
            animation = new DoubleAnimationUsingKeyFrames();
            Storyboard.SetTarget(animation, alumno);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));
            easyDoubleKeyFrame = new EasingDoubleKeyFrame();
            easyDoubleKeyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 5));
            easyDoubleKeyFrame.Value = 0;
            animation.KeyFrames.Add(easyDoubleKeyFrame);
            easyDoubleKeyFrame = new EasingDoubleKeyFrame();
            easyDoubleKeyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 10));
            easyDoubleKeyFrame.Value = 389;
            animation.KeyFrames.Add(easyDoubleKeyFrame);
            guion.Children.Add(animation);

 
            animation = new DoubleAnimationUsingKeyFrames();
            Storyboard.SetTarget(animation, alumnoRotation);
            Storyboard.SetTargetProperty(animation, new PropertyPath(RotateTransform.AngleProperty));
            easyDoubleKeyFrame = new EasingDoubleKeyFrame();
            easyDoubleKeyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 5));
            easyDoubleKeyFrame.Value = -90.0;
            animation.KeyFrames.Add(easyDoubleKeyFrame);
            easyDoubleKeyFrame = new EasingDoubleKeyFrame();
            easyDoubleKeyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 10));
            easyDoubleKeyFrame.Value = -360.0;
            animation.KeyFrames.Add(easyDoubleKeyFrame);
            guion.Children.Add(animation);
           
            
            /* DoubleAnimation ani = new DoubleAnimation();
             Storyboard.SetTarget(ani, alumno);
             Storyboard.SetTargetProperty(ani, new PropertyPath(Canvas.TopProperty));
             ani.From = 309;
             ani.To = 389;
             ani.Duration = new Duration(new TimeSpan(0, 0, 10));
             guion.Children.Add(ani);
         */
        }

        private void desaparecer()
        {
            /*      Thread t1 = new Thread(new ThreadStart(
          delegate ()
      {
          for (int opacity = 100; opacity > 0; opacity--)
          {
              this.Dispatcher.BeginInvoke(
                 new Action(delegate ()
                 {
                     logoUPM.Opacity = (float)opacity / 100.0;
                     logoEtsisi.Opacity = (100.0 - ((float)opacity % 101.0)) / 100.0; //%101 en caso de ser %100 en la primera pasada se veria.
                 }));
              Thread.Sleep(100);
          }
      }));
                  t1.Start();
                  */

            
            
                this.animacionLogoUpm();
                this.animacionLogoEtsisi();
               
              
            
        }

        private void animacionLogoEtsisi()
        {
            DoubleAnimation ani = new DoubleAnimation();
            Storyboard.SetTarget(ani, logoEtsisi);
            Storyboard.SetTargetProperty(ani, new PropertyPath(Image.OpacityProperty));
            if (logoEtsisi.Opacity == 1.0)
            {
                ani.From = 1;
                ani.To = 0;
            }
            else {
                ani.From = 0;
                ani.To = 1;
            }
  
            ani.Duration = new Duration(new TimeSpan(0, 0, 10));
            guion.Children.Add(ani);
            
        }

        private void animacionLogoUpm()
        {
            DoubleAnimation animation = new DoubleAnimation();
            Storyboard.SetTarget(animation, logoUPM);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Image.OpacityProperty));
            if(logoUPM.Opacity ==0){
                animation.From = 0;
                animation.To = 1;
            }

            else {
                animation.From = 1;
                animation.To = 0;
            }
            animation.Duration = new Duration(new TimeSpan(0, 0, 10));
            guion.Children.Add(animation);
        }



        // Código de ejemplo para compilar una ApplicationBar traducida
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}