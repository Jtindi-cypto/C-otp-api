// creating the otp model

using Amazon.SecurityToken.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace OtpReceiverApi.models{

    public class Otp{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}

       [BsonElement("mobileNumber")]
       public string mobileNumber{get;set;}

       [BsonElement("otp")]
       public string otpCode{get;set;}

       [BsonElement("createdAt")]
       public DateTime createdAt{get;set;} = DateTime.Now;

       [BsonElement("expiresAt")]
    // this code set the otp to expire after 5 minutes
       public DateTime expiresAt{get;set;} = DateTime.Now.AddMinutes(5);
       
    }
}