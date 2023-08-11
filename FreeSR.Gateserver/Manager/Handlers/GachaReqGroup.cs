namespace FreeSR.Gateserver.Manager.Handlers
{
    using FreeSR.Gateserver.Manager.Handlers.Core;
    using FreeSR.Gateserver.Network;
    using FreeSR.Proto;
    using static System.Net.WebRequestMethods;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.ComponentModel.Design;

    using System;

internal static class GachaReqGroup
{
    private static Random random = new Random();

    [Handler(CmdType.GetGachaInfoCsReq)]
    public static void OnGetGachaInfoCsReq(NetSession session, int cmdId, object data)
    {
        var Gacha1List = new List<int>();
        session.Send(CmdType.GetGachaInfoScRsp, new GetGachaInfoScRsp
        {
            Retcode = Retcode.RETCODE_RET_SUCC,
            GachaRandom = 21,
            GachaInfoList = new List<GachaInfo>
            {
                new GachaInfo
                {
                    ENJHJHKNGOG = "https://webstatic-sea.hoyoverse.com/hkrpg/event/e20211215gacha-v2/index.html?authkey_ver=1&sign_type=2&auth_appid=webview_gacha&win_mode=fullscreen#/log",
                    FMGHPCBPCDJ = new List<int>(1005),
                    KKCFLEOACMD = new List<int>{1111, 1108, 1103},
                    BeginTime = 1689719400,
                    EndTime = 4070880000,
                    GachaId = 2006
                }
            }
        });
    }

    [Handler(CmdType.DoGachaCsReq)]
    public static void OnDoGachaCsReq(NetSession session, int cmdId, object data)
    {
        var gachaReq = data as DoGachaCsReq;

        int randomValue = random.Next(1, 101);

        int itemId;
        if (randomValue <= 95)
        {
            itemId = 1001;
        }
        else if (randomValue <= 98)
        {
            itemId = 1005;
        }
        else
        {
            itemId = 1004;
        }

        session.Send(CmdType.DoGachaScRsp, new DoGachaScRsp
        {
            GachaId = gachaReq.GachaId,
            BBGOINCNNOB = gachaReq.GachaRandom + 1,
            GachaNum = gachaReq.GachaNum,
            GachaItemList = new List<GachaItem>
            {
                new GachaItem
                {
                    Item = new List<Item>
                    {
                        new Item
                        {
                            ItemId = itemId,
                            Num = 1,
                        }
                    }[0],
                    PODLGKLONKN = new List<ItemList>
                    {
                        new ItemList
                        {
                            List = new List<Item>
                            {
                                new Item
                                {
                                    ItemId = 252,
                                    Num = 40,
                                }
                            }
                        }
                    }[0]
                }
            },
        });
    }
}
