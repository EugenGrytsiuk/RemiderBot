using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class BotPhrases
    {
        [JsonProperty("helpp_text")]
        public string Help { get; set; }

        [JsonProperty("start_welcome_message")]
        public string Start { get; set; }

        [JsonProperty("registered_congratulation")]
        public string Registered { get; set; }

        [JsonProperty("not_registered")]
        public string NotRegistered { get; set; }

        [JsonProperty("has_already_been_registered")]
        public string AlreadyRegistered { get; set; }

        [JsonProperty("idea_sent_to_zoho")]
        public string MsgSent { get; set; }

        [JsonProperty("button_cancel_clicked")]
        public string MsgCanceled { get; set; }

        [JsonProperty("message_has_already_been_processed")]
        public string MsgAlreadySent { get; set; }
        [JsonProperty("question_save_idea")]
        public string Question { get; set; }
    }
}