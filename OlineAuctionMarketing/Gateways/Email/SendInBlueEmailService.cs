using OlineAuctionMarketing.Gateways.Email;
using OlineAuctionMarketing.Models;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;

namespace EasyLearn.GateWays.Email;

public class SendInBlueEmailService : ISendInBlueEmailService
{
    //private readonly IConfiguration _configuration;
    //private readonly SendinblueOptions _sendinblueOptions;

    //public SendInBlueEmailService(IOptions<SendinblueOptions> sendinblueOptions)
    //{
    //    //_configuration = configuration;
    //    _sendinblueOptions = sendinblueOptions.Value;
    //}


    public async Task<BaseResponse> SendEmail(EmailSenderDTO model)
    {
        var key = "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";
        var senderName = "Mustaeenah Agbaje";
        var senderEmail = "mustaeenaholadayo@gmail.com";

        Configuration.Default.ApiKey.Clear();
        Configuration.Default.ApiKey.Add("api-key", key);
        var apiInstance = new TransactionalEmailsApi();

        var emailSender = new SendSmtpEmailSender(senderName, senderEmail);

        var emailReciever = new SendSmtpEmailTo(model.ReceiverEmail, model.ReceiverEmail);

        var emailRecievers = new List<SendSmtpEmailTo>();
        emailRecievers.Add(emailReciever);

        var replyTo = new SendSmtpEmailReplyTo("treehays90@gmail.com", "Abdulsalam Ahmad");

        var subject = $"My Sample {model.Subject}";


        var htmlContent = model.Body;

        ////var stringInBase64 = "aGVsbG8gdGhpcyBpcyB0ZXN0";
        //var content = Convert.FromBase64String(stringInBase64);
        //var attachmentContent = new SendSmtpEmailAttachment
        //{
        //    Content = content,
        //    Name = "Attachment.txt"
        //};
        //var attachment = new List<SendSmtpEmailAttachment>();
        //attachment.Add(attachmentContent);

        var sendSmtpEmail = new SendSmtpEmail
        {
            Sender = emailSender,
            HtmlContent = htmlContent,
            Subject = subject,
            ReplyTo = replyTo,
            To = emailRecievers,
            //Attachment = attachment,
        };
       
        try
        {
            var result = await apiInstance.SendTransacEmailAsync(sendSmtpEmail);

            return new BaseResponse
            {
                Status = true,
                Massage = "Email successfully sent..",
            };
        }
        catch (Exception)
        {

            return new BaseResponse
            {
                Status = true,
                Massage = "Email not sent..",
            };
        }
    }
}














