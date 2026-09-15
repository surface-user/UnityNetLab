using System.Net;
using System.Net.Sockets;
using UnityEngine;

class TcpServer : MonoBehaviour{
    private TcpListener tcplistener;
    private TcpClient connectedClient;
    //创建并启动监听器
    private void Start(){
       IPAddress ipaddress = IPAddress.Loopback;
        int port = 7777;
        if(tcplistener == null){
            tcplistener = new TcpListener(ipaddress, port);
            tcplistener.Start();
            Debug.Log("Server 开始监听");
        }
    }
    //在游戏销毁时停止监听
    private void OnDestroy(){
        if(tcplistener !=null){
            tcplistener.Stop();
            Debug.Log("Server 停止监听");
            // Debug.Log 是 Unity 提供的调试输出方法，用于在 Console 控制台打印普通调试信息；
            //参数支持字符串、变量、对象等任意可转字符串的内容，常用于运行时排查逻辑、查看状态
        }
        if(connectedClient!=null){
            connectedClient.Close();
            Debug.Log("Server 关闭客户端连接");
        }
    }

    private void Update(){
         if(connectedClient!=null) return;
         if(!tcplistener.Pending()) return;
         connectedClient=tcplistener.AcceptTcpClient();
         Debug.Log("Server 接受客户端连接");
    }
}

