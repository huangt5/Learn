/**
 * Created by Administrator on 11/22/2016.
 */
import org.springframework.context.support.ClassPathXmlApplicationContext;
import test.dubbo.service.DemoService;

public class ClientApp {

    public static void main(String[] args) {


        ClassPathXmlApplicationContext context = new ClassPathXmlApplicationContext(
                new String[] { "applicationConsumer.xml" });
        context.start();
        DemoService demoService = (DemoService) context.getBean("demoService"); // get
        // service
        // invocation
        // proxy
        String hello = "";
        try {
            hello = demoService.build("Terry");
        } catch (Exception e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } // do invoke!
        System.out.println(Thread.currentThread().getName() + " " + hello);
    }

}
