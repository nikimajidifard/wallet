using wallet.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;


namespace Wallet.Application.Mapper
{
    public class Mapper
    {
        public class WalletMappingProfile : Profile
        {
            public WalletMappingProfile()
            {
                CreateMap<Company, CompanyDto>().ReverseMap();
                CreateMap<WalletE, WalletEDto>().ReverseMap();
                CreateMap<Transaction, TransactionDto>().ReverseMap();
                CreateMap<User, UserDto>().ReverseMap();
                CreateMap<Label, LabelDto>().ReverseMap();
                CreateMap<Notification, NotificationDto>().ReverseMap();
                CreateMap<EmailNotification, EmailNotificationDto>().ReverseMap();
                CreateMap<PushNotification, PushNotificationDto>().ReverseMap();
                CreateMap<SMSNotification, SMSNotificationDto>().ReverseMap();


            }
        }
    }
}
