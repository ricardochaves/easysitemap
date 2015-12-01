﻿using EasySiteMap.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySiteMap
{
    public class SiteMapItem : ISiteMapItem
    {
        /// <summary>
        /// Store for the ChangeFrequency property.</summary>
        private ChangeFrequency? _changefrequency;

        /// <summary>
        /// Store for the LastModified property.</summary>
        private DateTime? _lastmodified;

        /// <summary>
        /// Store for the Priority property.</summary>
        private double? _priority;

        /// <summary>
        /// Store for the URL property.</summary>
        private string _url;

        public SiteMapItem(string url, DateTime? lastmodified,  ChangeFrequency? change, double? priority)
        {
            _lastmodified = lastmodified;
            _priority = priority;
            _url = url;
            _changefrequency = change;
        }

        public SiteMapItem(string url)
        {
            _url = url;
        }

        public SiteMapItem(){}

        /// <summary>
        /// ChangeFrequency </summary>
        /// <value>
        /// Frequency in which the contents of the URL is updated.</value>
        public ChangeFrequency? ChangeFrequency
        {
            get
            {
                return _changefrequency;
            }

            set
            {
                _changefrequency = value;
            }
        }

        /// <summary>
        /// LastModified </summary>
        /// <value>
        /// The date that the content URL has been changed.</value>
        public DateTime? LastModified
        {
            get
            {
                return _lastmodified;
            }

            set
            {
                _lastmodified = value;
            }
        }

        /// <summary>
        /// Priority </summary>
        /// <value>
        /// The priority of the URL of all your site's URLs.</value>
        public double? Priority
        {
            get
            {
                return _priority;
            }

            set
            {
                _priority = value;
            }
        }

        /// <summary>
        /// URL </summary>
        /// <value>
        /// URL mapped.</value>
        public string URL
        {
            get
            {
                return _url;
            }

            set
            {
                _url = value;
            }
        }
    }
}
