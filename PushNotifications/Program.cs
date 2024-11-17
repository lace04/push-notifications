using System;
using System.ServiceProcess;

namespace PushNotifications
{
  static class Program
  {
    // Punto de entrada principal
    static void Main()
    {
      ServiceBase[] ServicesToRun;
      ServicesToRun = new ServiceBase[]
      {
                new PushNotificationService() // Instancia de tu servicio
      };
      ServiceBase.Run(ServicesToRun); // Ejecuta el servicio
    }
  }
}
