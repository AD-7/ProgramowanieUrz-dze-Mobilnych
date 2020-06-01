using System;
using System.Collections.Generic;
using System.Text;

namespace Communication
{
    public enum MESSAGE_TYPE
    {    NONE, SEND_REPORT_CFM,
        GET_MENU_REQ, GET_ACTIVE_ORDERS_REQ, GET_COMPLETED_ORDERS_REQ, GET_ACTIVE_DELIVERIES_REQ, GET_COMPLETED_DELIVERIES_REQ,
        GET_ALL_CLIENTS_REQ, GET_ORDER_BYID_REQ, GET_DELIVERY_BYID_REQ, CREATE_CLIENT_REQ, CREATE_DISH_REQ, CREATE_ORDER_REQ, COMPLETE_ORDER_REQ, COMPLETE_DELIVERY_REQ,

        GET_MENU_CFM, GET_ACTIVE_ORDERS_CFM, GET_COMPLETED_ORDERS_CFM, GET_ACTIVE_DELIVERIES_CFM, GET_COMPLETED_DELIVERIES_CFM, GET_ALL_CLIENTS_CFM,
        GET_ORDER_BYID_CFM, GET_DELIVERY_BYID_CFM, CREATE_CLIENT_CFM, CREATE_DISH_CFM, CREATE_ORDER_CFM, COMPLETE_ORDER_CFM, COMPLETE_DELIVERY_CFM
    }

    public class CommunicationType
    {
        public MESSAGE_TYPE MessageType { get; set; }
        public string Message { get; set; }
        public List<string> Parameters { get; set; }
        public CommunicationType(MESSAGE_TYPE MsgType, string Msg, List<string> param)
        {
            MessageType = MsgType;
            Message = Msg;
            Parameters = param;
        }

        public CommunicationType()
        {
            MessageType = MESSAGE_TYPE.NONE;
            Message = "";
            Parameters = null;
        }


    }
}
