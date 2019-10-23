using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CompatCheckAndMigrate.Helpers;
using CompatCheckAndMigrate.ObjectModel;

namespace CompatCheckAndMigrate.Controls
{
    public partial class SiteStatusControl : UserControl, IWizardStep
    {
        private IISServers IISServers;
        private IISServer _server;

        public SiteStatusControl()
        {
            InitializeComponent();
            IISServers = null;
            _server = null;
        }

        public event EventHandler<GoToWizardStepEventArgs> GoTo;

        public void SetState(object state, bool isNavigatingBack = false)
        {
            if (state != null)
            {
                this.IISServers = (IISServers)state;
                this._server = (IISServer)state;
            }
        }

        private void FireGoToEvent(WizardSteps step, object state = null)
        {
            EventHandler<GoToWizardStepEventArgs> _goTo = GoTo;
            if (_goTo != null)
            {
                _goTo(this, new GoToWizardStepEventArgs(step, state));
            }
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            FireGoToEvent(WizardSteps.FeedbackPage, this.IISServers);
            FireGoToEvent(WizardSteps.FeedbackPage, this._server);
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            FireGoToEvent(WizardSteps.InstallWebDeploy, this.IISServers);
            FireGoToEvent(WizardSteps.InstallWebDeploy, this._server);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void SiteStatusControl_Load(object sender, EventArgs e)
        {
            if (this.IISServers != null)
            {
                foreach (var server in this.IISServers.Servers.Values)
                {
                    foreach (var site in server.Sites.Where(s => s.PublishProfile != null && !string.IsNullOrEmpty(s.PublishProfile.SiteName)))
                    {
                        var siteItem = new SiteItemControl(site.PublishProfile.SiteName, string.IsNullOrEmpty(site.SiteCreationError));
                        siteItem.Dock = DockStyle.Top;
                        statusPanel.Controls.Add(siteItem);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(TraceHelper.Tracer.TraceFile);
        }
            if (this._server != null)
            {
                foreach (var site in this._server.Sites.Where(s => s.PublishProfile != null && !string.IsNullOrEmpty(s.PublishProfile.SiteName)))
                {
                    var siteItem = new SiteItemControl(site.PublishProfile.SiteName, string.IsNullOrEmpty(site.SiteCreationError));
                    siteItem.Dock = DockStyle.Top;
                    statusPanel.Controls.Add(siteItem);
                }
            }
        }
    }
}
