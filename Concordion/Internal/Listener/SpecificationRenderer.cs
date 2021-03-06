// Copyright 2009 Jeffrey Cameron
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Concordion.Api;
using Concordion.Api.Listener;

namespace Concordion.Internal.Listener
{
    public class SpecificationRenderer : ISpecificationProcessingListener
    {
        #region Fields
		        
        private static readonly string XML_DECLARATION = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

	    #endregion

        #region Properties

        private ITarget Target
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public SpecificationRenderer(ITarget target)
        {
            this.Target = target;
        }

        #endregion

        #region ISpecificationProcessingListener Members

        public void BeforeProcessingSpecification(SpecificationProcessingEvent processingEvent)
        {
            // No action required
        }

        public void AfterProcessingSpecification(SpecificationProcessingEvent processingEvent)
        {
            try 
            {
                this.Target.Write(processingEvent.Resource, XML_DECLARATION + processingEvent.RootElement.ToXml());
                var description = this.Target.ResolvedPathFor(processingEvent.Resource);
                if (!string.IsNullOrEmpty(description))
                {
                    Console.WriteLine("Processed: {0}", description);
                }
            } 
            catch (Exception e) 
            {
                throw new Exception("Failed to write results to '" + processingEvent.Resource.Path + "'.", e);
            }
        }

        #endregion
    }
}
