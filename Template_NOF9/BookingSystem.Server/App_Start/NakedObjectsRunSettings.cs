// Copyright Naked Objects Group Ltd, 45 Station Road, Henley on Thames, UK, RG9 1AT
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0.
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and limitations under the License.

using System;
using NakedObjects.Architecture.Menu;
using NakedObjects.Core.Configuration;
using NakedObjects.Menu;
using NakedObjects.Persistor.Entity.Configuration;
using BookingSystem.Model;
using BookingSystem.DataBase;
using TechnicalServices;
using NakedObjects.Meta.Authorization;

namespace NakedObjects.BookingSystem {
    public class NakedObjectsRunSettings
    {

        public static string RestRoot
        {
            get { return ""; }
        }

        private static string[] ModelNamespaces
        {
            get
            {
                return new string[] { "BookingSystem.Model" }; //Add top-level namespace(s) that cover the domain model
            }
        }

        private static Type[] Types
        {
            get
            {
                return new Type[] {
                    //You need only register here any domain model types that cannot be
                    //'discovered' by the framework when it 'walks the graph' from the methods
                    //defined on services registered below
                };
            }
        }

        private static Type[] Services
        {
            get
            {
                return new Type[] {
                    typeof(PupilRepository),
                    typeof(AppointmentRepository),
                    typeof(ParentRepostiory),
                    typeof(Registration_Form_Repository),
                   
                    typeof(OrderRepository),
                    typeof(Product_Repostitory),
                    typeof(RecomendedItemsRepository),
                    typeof(ManagerRepository),
                    typeof(Information_Repository),                                      
                    typeof(SMTPMailServer),
                     //typeof(MockEmailsender),
                };
            }
        }

        public static ReflectorConfiguration ReflectorConfig()
        {
            return new ReflectorConfiguration(Types, Services, ModelNamespaces, MainMenus);
        }

        public static EntityObjectStoreConfiguration EntityObjectStoreConfig()
        {
            var config = new EntityObjectStoreConfiguration();
            config.UsingCodeFirstContext(() => new BookingSystemDbContext("NakedObjectsTemplate"));
            return config;
        }


        public static IMenu[] MainMenus(IMenuFactory factory)
        {
            return new IMenu[] {
                factory.NewMenu<PupilRepository>(true, "Pupil"),
                factory.NewMenu<AppointmentRepository>(true, "Appointment"),
                factory.NewMenu<ParentRepostiory>(true, "Parent"),
                factory.NewMenu<OrderRepository>(true, "Order"),
                factory.NewMenu<Product_Repostitory>(true, "Products"),
                factory.NewMenu<RecomendedItemsRepository>(true, "Recomended Items"),
                factory.NewMenu<Registration_Form_Repository>(true, "Book an Appointment"),
                factory.NewMenu<ManagerRepository>(true, "Manager"),
                factory.NewMenu<Information_Repository>(true, "Information")

                //factory.NewMenu<OrderLineRepository>(true, "OrderLine")


            };
        }
        public static IAuthorizationConfiguration AuthorizationConfig()
        {
            var config = new AuthorizationConfiguration<Authorizer>();
           
            return config;
        }
        
    }
}