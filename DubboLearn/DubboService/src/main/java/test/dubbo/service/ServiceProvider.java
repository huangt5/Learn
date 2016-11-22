package test.dubbo.service;

import org.springframework.context.support.ClassPathXmlApplicationContext;


/**
 * Created by Administrator on 11/22/2016.
 */
public class ServiceProvider {

    public static void main(String[] args) throws Exception {

        ClassPathXmlApplicationContext context = new ClassPathXmlApplicationContext(new String[] {"ApplicationContext.xml"});
        context.start();

        System.out.println("Service running...");

        System.in.read(); // 按任意键退出
    }

}
