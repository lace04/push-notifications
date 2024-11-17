using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

[RunInstaller(true)]
public class ProjectInstaller : Installer
{
  private ServiceProcessInstaller serviceProcessInstaller;
  private ServiceInstaller serviceInstaller;

  public ProjectInstaller()
  {
    // Configurar el instalador del proceso del servicio
    serviceProcessInstaller = new ServiceProcessInstaller
    {
      Account = ServiceAccount.LocalSystem // Configurar para que el servicio use la cuenta del sistema local
    };

    // Configurar el instalador del servicio
    serviceInstaller = new ServiceInstaller
    {
      ServiceName = "PushNotifications", // Nombre del servicio
      DisplayName = "Push Notifications Service", // Nombre amigable del servicio
      StartType = ServiceStartMode.Automatic // Configuración para inicio automático
    };

    // Agregar los instaladores al instalador de proyecto
    Installers.Add(serviceProcessInstaller);
    Installers.Add(serviceInstaller);
  }
}
