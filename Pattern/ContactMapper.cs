//Implementing Fluent API Pattern on database table 
// This file defines the Fluent API configuration for the Contacts entity.

using ContactsAPI.Models;       // Imports the namespace where the Contacts model is defined.
using Microsoft.EntityFrameworkCore.Metadata.Builders;      // Imports the Fluent API configuration tools.

namespace ContactsAPI.Pattern;      // Defines the namespace for the current class.

    public class ContactMapper      // This class is responsible for configuring the entity mapping for the Contacts model using Fluent API.
    {
        // Constructor that takes an EntityTypeBuilder for Contacts as a parameter.
        // EntityTypeBuilder is used to configure the mapping of the Contacts entity to the database table.
        public ContactMapper(EntityTypeBuilder<Contacts> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t=>t.ID);      // Configures the Id property of the Contacts entity as the primary key.
            entityTypeBuilder.Property(t => t.FirstName).IsRequired();      // Configures the FirstName property as a required field in the database.
            entityTypeBuilder.Property(t => t.LastName).IsRequired();       // Configures the LastName property as a required field in the database.
            entityTypeBuilder.Property(t => t.Company).IsRequired();        // Configures the Company property as a required field in the database.
        }
    }
 