﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("Domain", "FK__Article__AuthorId__aspnet_Users__UserId", "User", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Domain.User), "Article", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Domain.Article), true)]

#endregion

namespace Domain
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class Entities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new Entities object using the connection string found in the 'Entities' section of the application configuration file.
        /// </summary>
        public Entities() : base("name=Entities", "Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(string connectionString) : base(connectionString, "Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(EntityConnection connection) : base(connection, "Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Article> Articles
        {
            get
            {
                if ((_Articles == null))
                {
                    _Articles = base.CreateObjectSet<Article>("Articles");
                }
                return _Articles;
            }
        }
        private ObjectSet<Article> _Articles;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Articles EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToArticles(Article article)
        {
            base.AddObject("Articles", article);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Domain", Name="Article")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Article : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Article object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="authorId">Initial value of the AuthorId property.</param>
        /// <param name="title">Initial value of the Title property.</param>
        /// <param name="summary">Initial value of the Summary property.</param>
        /// <param name="body">Initial value of the Body property.</param>
        /// <param name="version">Initial value of the Version property.</param>
        public static Article CreateArticle(global::System.Int32 id, global::System.Guid authorId, global::System.String title, global::System.String summary, global::System.String body, global::System.Byte[] version)
        {
            Article article = new Article();
            article.Id = id;
            article.AuthorId = authorId;
            article.Title = title;
            article.Summary = summary;
            article.Body = body;
            article.Version = version;
            return article;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid AuthorId
        {
            get
            {
                return _AuthorId;
            }
            set
            {
                OnAuthorIdChanging(value);
                ReportPropertyChanging("AuthorId");
                _AuthorId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AuthorId");
                OnAuthorIdChanged();
            }
        }
        private global::System.Guid _AuthorId;
        partial void OnAuthorIdChanging(global::System.Guid value);
        partial void OnAuthorIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Summary
        {
            get
            {
                return _Summary;
            }
            set
            {
                OnSummaryChanging(value);
                ReportPropertyChanging("Summary");
                _Summary = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Summary");
                OnSummaryChanged();
            }
        }
        private global::System.String _Summary;
        partial void OnSummaryChanging(global::System.String value);
        partial void OnSummaryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Body
        {
            get
            {
                return _Body;
            }
            set
            {
                OnBodyChanging(value);
                ReportPropertyChanging("Body");
                _Body = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Body");
                OnBodyChanged();
            }
        }
        private global::System.String _Body;
        partial void OnBodyChanging(global::System.String value);
        partial void OnBodyChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte[] Version
        {
            get
            {
                return StructuralObject.GetValidValue(_Version);
            }
            set
            {
                OnVersionChanging(value);
                ReportPropertyChanging("Version");
                _Version = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Version");
                OnVersionChanged();
            }
        }
        private global::System.Byte[] _Version;
        partial void OnVersionChanging(global::System.Byte[] value);
        partial void OnVersionChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Domain", "FK__Article__AuthorId__aspnet_Users__UserId", "User")]
        public User Author
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("Domain.FK__Article__AuthorId__aspnet_Users__UserId", "User").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("Domain.FK__Article__AuthorId__aspnet_Users__UserId", "User").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> AuthorReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("Domain.FK__Article__AuthorId__aspnet_Users__UserId", "User");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("Domain.FK__Article__AuthorId__aspnet_Users__UserId", "User", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Domain", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="applicationId">Initial value of the ApplicationId property.</param>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="userName">Initial value of the UserName property.</param>
        /// <param name="loweredUserName">Initial value of the LoweredUserName property.</param>
        /// <param name="isAnonymous">Initial value of the IsAnonymous property.</param>
        /// <param name="lastActivityDate">Initial value of the LastActivityDate property.</param>
        public static User CreateUser(global::System.Guid applicationId, global::System.Guid userId, global::System.String userName, global::System.String loweredUserName, global::System.Boolean isAnonymous, global::System.DateTime lastActivityDate)
        {
            User user = new User();
            user.ApplicationId = applicationId;
            user.UserId = userId;
            user.UserName = userName;
            user.LoweredUserName = loweredUserName;
            user.IsAnonymous = isAnonymous;
            user.LastActivityDate = lastActivityDate;
            return user;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ApplicationId
        {
            get
            {
                return _ApplicationId;
            }
            set
            {
                OnApplicationIdChanging(value);
                ReportPropertyChanging("ApplicationId");
                _ApplicationId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ApplicationId");
                OnApplicationIdChanged();
            }
        }
        private global::System.Guid _ApplicationId;
        partial void OnApplicationIdChanging(global::System.Guid value);
        partial void OnApplicationIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                if (_UserId != value)
                {
                    OnUserIdChanging(value);
                    ReportPropertyChanging("UserId");
                    _UserId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserId");
                    OnUserIdChanged();
                }
            }
        }
        private global::System.Guid _UserId;
        partial void OnUserIdChanging(global::System.Guid value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                OnUserNameChanging(value);
                ReportPropertyChanging("UserName");
                _UserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserName");
                OnUserNameChanged();
            }
        }
        private global::System.String _UserName;
        partial void OnUserNameChanging(global::System.String value);
        partial void OnUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LoweredUserName
        {
            get
            {
                return _LoweredUserName;
            }
            set
            {
                OnLoweredUserNameChanging(value);
                ReportPropertyChanging("LoweredUserName");
                _LoweredUserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LoweredUserName");
                OnLoweredUserNameChanged();
            }
        }
        private global::System.String _LoweredUserName;
        partial void OnLoweredUserNameChanging(global::System.String value);
        partial void OnLoweredUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MobileAlias
        {
            get
            {
                return _MobileAlias;
            }
            set
            {
                OnMobileAliasChanging(value);
                ReportPropertyChanging("MobileAlias");
                _MobileAlias = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MobileAlias");
                OnMobileAliasChanged();
            }
        }
        private global::System.String _MobileAlias;
        partial void OnMobileAliasChanging(global::System.String value);
        partial void OnMobileAliasChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsAnonymous
        {
            get
            {
                return _IsAnonymous;
            }
            set
            {
                OnIsAnonymousChanging(value);
                ReportPropertyChanging("IsAnonymous");
                _IsAnonymous = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsAnonymous");
                OnIsAnonymousChanged();
            }
        }
        private global::System.Boolean _IsAnonymous;
        partial void OnIsAnonymousChanging(global::System.Boolean value);
        partial void OnIsAnonymousChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastActivityDate
        {
            get
            {
                return _LastActivityDate;
            }
            set
            {
                OnLastActivityDateChanging(value);
                ReportPropertyChanging("LastActivityDate");
                _LastActivityDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastActivityDate");
                OnLastActivityDateChanged();
            }
        }
        private global::System.DateTime _LastActivityDate;
        partial void OnLastActivityDateChanging(global::System.DateTime value);
        partial void OnLastActivityDateChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Domain", "FK__Article__AuthorId__aspnet_Users__UserId", "Article")]
        public EntityCollection<Article> Articles
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Article>("Domain.FK__Article__AuthorId__aspnet_Users__UserId", "Article");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Article>("Domain.FK__Article__AuthorId__aspnet_Users__UserId", "Article", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
