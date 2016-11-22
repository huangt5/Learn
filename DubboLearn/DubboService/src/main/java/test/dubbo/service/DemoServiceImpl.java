package test.dubbo.service;

/**
 * Created by Administrator on 11/22/2016.
 */
public class DemoServiceImpl implements DemoService {
    public String build(String name) throws Exception {
        System.out.println("name is === " + name);
        return "Hello " + name + "!";
    }
}
