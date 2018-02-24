using System;

using drawboard.ApiModels;

namespace drawboard.ViewModels
{
    /// <summary>
    /// Wraps a <see cref="Project"/> object to allow it to be collapsed and expanded.
    /// Not ideal.. but couldn't figure out the relative binding in UWP. Currently read-only
    /// except for <see cref="IsUserCardExpanded"/>. Can be made read-write. Not too big of a deal,
    /// but will add a slight memory and performance overhead. May consider getting rid
    /// of the ApiModels and making those into VMs straight away? Need more understanding of 
    /// converting Jsons to objects and doing that to VMs - any side-effects, etc.
    /// </summary>
    public class ProjectViewModel : ViewModelBase
    {
        private Project project;
        private bool isUserCardExpanded;

        /// <summary>
        /// Ctor - wraps a <see cref="Project"/> in a VM
        /// </summary>
        public ProjectViewModel(Project project)
        {
            this.project = project;
        }

        public string Id => project.Id;
        public string Name => project.Name;
        public string Description => project.Description;
        public int Status => project.Status;
        public string Permissions => project.Permissions;
        public UserCard Owner => project.Owner;
        public DateTime? DeletedOn => project.DeletedOn;

        public bool IsUserCardExpanded
        {
            get => isUserCardExpanded;
            set
            {
                isUserCardExpanded = value;
                RaisePropertyChanged(nameof(IsUserCardExpanded));
            }
        }

        public override string ToString()
        {
            return project.ToString();
        }
    }
}
