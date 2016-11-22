package simpleTest;

/**
 * Created by Administrator on 11/19/2016.
 */
public class ClassOverride {
    public static class BaseClass{
        public BaseClass() {
        }

        public void run(){
            System.out.println("base class");
        }
    }

    public static class SubClass extends BaseClass{
        public SubClass() {
        }

        @Override
        public void run() {
            System.out.println("sub class");
        }
    }

    public static void main(String[] args) {
        BaseClass inst = new SubClass();
        inst.run();
    }
}
