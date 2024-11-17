using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace PushNotifications
{
  public partial class PushNotificationService : ServiceBase
  {
    private Timer _timer;

    public PushNotificationService()
    {
      // Configuración básica del servicio
      this.ServiceName = "PushNotifications";
      this.CanStop = true;
      this.CanPauseAndContinue = true;
      this.AutoLog = true;

      // Configurar el EventLog para registrar eventos
      if (!EventLog.SourceExists("PushNotifications"))
      {
        EventLog.CreateEventSource("PushNotifications", "Application");
      }
      EventLog.Source = "PushNotifications";
      EventLog.Log = "Application";
    }

    // Lógica para cuando el servicio inicia
    protected override void OnStart(string[] args)
    {
      EventLog.WriteEntry("Servicio PushNotifications iniciado.");

      // Configurar un temporizador para realizar tareas periódicas
      _timer = new Timer(60000); // 60,000 ms = 1 minuto
      _timer.Elapsed += (sender, e) =>
      {
        // Lógica para ejecutar en cada intervalo
        EventLog.WriteEntry("Ejecutando tarea periódica de prueba.");
      };
      _timer.Start(); // Iniciar el temporizador
    }

    // Lógica para cuando el servicio se detiene
    protected override void OnStop()
    {
      // Limpiar recursos
      if (_timer != null)
      {
        _timer.Stop();
        _timer.Dispose();
      }
      EventLog.WriteEntry("Servicio PushNotifications detenido.");
    }
  }
}
