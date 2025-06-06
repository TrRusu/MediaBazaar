using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    abstract class Message
    {
        public string tableName = "announcements";

        public List<string> toSelect;
        public List<string> whereValues;
        public List<string> whereNames;
        public List<string> columnValues;
        public List<string> columnNames;
        public List<string> setColumnName;
        public List<string> setColumnValue;

        public List<Message> localMessages = new List<Message>();
        public List<Message> localMessagesByDate = new List<Message>();

        public DatabaseConnection database;

        public int MessageID
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public void DeleteMessage(int msgID)
        {

            database = new DatabaseConnection();

            columnValues = new List<string>()
            {
                msgID.ToString()
            };

            columnNames = new List<string>()
            {
                "msgID"
            };

            database.DeleteFromDatabase(tableName, columnValues, columnNames);
            DeleteMessageFromLocalList(msgID);
        }

        private void DeleteMessageFromLocalList(int msgID)
        {
           
            for(int i = 0; i < localMessages.Count; i++)
            {
                if(localMessages[i].MessageID == msgID)
                {
                    localMessages.Remove(localMessages[i]);
                }
            }
        }

        public List<Message> ReturnLocalMessagesList()
        {
            return localMessages;
        }

        public int NextMessageIdFromDatabase()
        {
            // I subtract 1 because message is already added to database

            return database.GetFromSchema("announcements") - 1;
        }

        public int GetMessageId(int index)
        {
            int messageID = 0;

            for(int i = 0; i < localMessagesByDate.Count; i++)
            {
                if(i == index)
                {
                    messageID = localMessagesByDate[i].MessageID;
                }
            }
            return messageID;
        }
    }
}
