using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace EMR.WinformDesigner
{
	public enum LoaderType
	{
		BasicDesignerLoader = 1,
		CodeDomDesignerLoader = 2,
		NoLoader = 3
	}

    /// <summary>
    /// Manages numerous HostSurfaces. Any services added to HostSurfaceManager
    /// will be accessible to all HostSurfaces
    /// </summary>
	public class HostSurfaceManager : DesignSurfaceManager
	{
		public HostSurfaceManager() : base()
		{
			this.AddService(typeof(INameCreationService), new NameCreationService());
		}

		protected override DesignSurface CreateDesignSurfaceCore(IServiceProvider parentProvider)
		{
			return new HostSurface(parentProvider);
		}

        /// <summary>
        /// Gets a new HostSurface and loads it with the appropriate type of
        /// root component. 
        /// </summary>
        private HostControl GetNewHost(Type rootComponentType)
		{
			HostSurface hostSurface = (HostSurface)this.CreateDesignSurface(this.ServiceContainer);

			if (rootComponentType == typeof(Form))
				hostSurface.BeginLoad(typeof(Form));
			else if (rootComponentType == typeof(UserControl))
				hostSurface.BeginLoad(typeof(UserControl));
			else if (rootComponentType == typeof(Component))
				hostSurface.BeginLoad(typeof(Component));
            else if (rootComponentType == typeof(MyTopLevelComponent))
                hostSurface.BeginLoad(typeof(MyTopLevelComponent));
            else
				throw new Exception("Undefined Host Type: " + rootComponentType.ToString());

			hostSurface.Initialize();
			this.ActiveDesignSurface = hostSurface;
			return new HostControl(hostSurface);
		}

        /// <summary>
        /// Gets a new HostSurface and loads it with the appropriate type of
        /// root component. Uses the appropriate Loader to load the HostSurface.
        /// </summary>
		public HostControl GetNewHost(Type rootComponentType, LoaderType loaderType)
		{
			if (loaderType == LoaderType.NoLoader)
				return GetNewHost(rootComponentType);

			HostSurface hostSurface = (HostSurface)this.CreateDesignSurface(this.ServiceContainer);
			IDesignerHost host = (IDesignerHost)hostSurface.GetService(typeof(IDesignerHost));

			switch (loaderType)
			{
				case LoaderType.BasicDesignerLoader :
					BasicHostLoader basicHostLoader = new BasicHostLoader(rootComponentType);
					hostSurface.BeginLoad(basicHostLoader);
					hostSurface.Loader = basicHostLoader;
					break;

				case LoaderType.CodeDomDesignerLoader :
					CodeDomHostLoader codeDomHostLoader = new CodeDomHostLoader();
					hostSurface.BeginLoad(codeDomHostLoader);
					hostSurface.Loader = codeDomHostLoader;
					break;

				default:
					throw new Exception("Loader is not defined: " + loaderType.ToString());
			}

			hostSurface.Initialize();
			return new HostControl(hostSurface);
		}

        /// <summary>
        /// Opens an Xml file and loads it up using BasicHostLoader (inherits from
        /// BasicDesignerLoader)
        /// </summary>
		public HostControl GetNewHostByByte(byte [] b)
		{
			if (b == null )
				MessageBox.Show("����ʧ��");

			LoaderType loaderType = LoaderType.NoLoader;

     		loaderType = LoaderType.BasicDesignerLoader;

			HostSurface hostSurface = (HostSurface)this.CreateDesignSurface(this.ServiceContainer);
			IDesignerHost host = (IDesignerHost)hostSurface.GetService(typeof(IDesignerHost));

            BasicHostLoader basicHostLoader = new BasicHostLoader(b);
            hostSurface.BeginLoad(basicHostLoader);
            hostSurface.Loader = basicHostLoader;
    		hostSurface.Initialize();
			return new HostControl(hostSurface);
		}




		public void AddService(Type type, object serviceInstance)
		{
			this.ServiceContainer.AddService(type, serviceInstance);
		}
	
	}// class
}// namespace
