
using OlineAuctionMarketing.Gateways.Email;
using OlineAuctionMarketing.Models;

namespace EasyLearn.GateWays.Email;

public interface ISendInBlueEmailService
{
    Task<BaseResponse> SendEmail(EmailSenderDTO model);
    //Task<BaseResponse> SendEmailAttachment(EmailSenderAttachmentDTO model);

}
