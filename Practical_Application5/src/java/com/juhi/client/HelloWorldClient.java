/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.juhi.client;
import java.net.URL;
import javax.xml.namespace.QName;
import com.juhi.ws.HelloWorld;
import jakarta.mail.Service;
/**
 *
 * @author hrisabhy
 */
public class HelloWorldClient {
    public static void main(String[] args) throws Exception{
        URL url = new URL("http://localhost:7779/ws/hello?wsdl");
        QName qname = new QName("http://ws.juhi.com/", "HelloWorldImplService");
 
        Service service = Service.create(url, qname);
 
        HelloWorld hello = service.getPort(HelloWorld.class);
 
        System.out.println(hello.getHelloWorldAsString("hrisabhy"));
    }
}