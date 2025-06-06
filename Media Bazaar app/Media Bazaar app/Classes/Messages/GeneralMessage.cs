using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    class GeneralMessage : Message
    {

        public string MessageBody
        {
            get;
            private set;
        }

        public string Title
        {
            get;
            private set;
        }

        public string Date
        {
            get;
            private set;
        }

        public GeneralMessage() { }

        public GeneralMessage(int id, string messageBody, string title, string date)
        {
            MessageID = id;
            Type = "General";
            MessageBody = messageBody;
            Title = title;
            Date = date;
        }

        public void CreateGeneralMessage(string messageBody, string title, string date)
        {
            ValidationManager applicationManager = new ValidationManager();

            if (applicationManager.ValidateGeneralMessage(title, messageBody))
            {

                string type = "General";
                setColumnName = new List<string>()
            {
               "title",
               "msgBody",
               "type",
               "date"
            };

                setColumnValue = new List<string>()
            {
               title,
               messageBody,
               type,
               date
            };

                database = new DatabaseConnection();
                database.InsertIntoDatabase(tableName, setColumnValue, setColumnName);
                CreateMessageInLocalList(messageBody, title, date);
            }
        }

        private void CreateMessageInLocalList(string messageBody, string title, string date)
        {
            localMessages.Add(new GeneralMessage(NextMessageIdFromDatabase(), messageBody, title, date));
        }

        public void GetGeneralMessagesFromDatabase()
        {
            string messageType = "General";
            database = new DatabaseConnection();

            localMessages.Clear();

            toSelect = new List<string>()
            {
                "msgID",
                "msgBody",
                "title",
                "date"
            };

            whereNames = new List<string>()
            {
                "type"
            };

            whereValues = new List<string>()
            {
                messageType
            };

            foreach (DataRow reader in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localMessages.Add(new GeneralMessage(Convert.ToInt32(reader[0].ToString()),
                                  reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
            }
        }

        public List<Message> ReturnMessagesByDate(string date)
        {
            localMessagesByDate = new List<Message>();

            foreach(Message message in localMessages)
            {
                if(((GeneralMessage)message).Date == date)
                {
                    localMessagesByDate.Add(message);
                }
            }
            return localMessagesByDate;
        }

        public override string ToString()
        {
            return Title;
        }

        public string GetMessageBody(int index)
        {
            string messageBody = "";

            for (int i = 0; i < localMessagesByDate.Count; i++)
            {
                if (localMessagesByDate[i].MessageID == GetMessageId(index))
                {
                    messageBody = ((GeneralMessage)localMessagesByDate[i]).MessageBody;
                }
            }
            return messageBody;
        }
    }
}
