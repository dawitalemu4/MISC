public class shhhhhhh {
    // i want java to show up as the main language in this repo, you didn't see anything😳



























































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































    // please checkout my other stuff


    import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.Scanner;

import javax.swing.JFileChooser;
import javax.swing.UIManager;


public class WordCount {

    public static void main(String[] args) {
        countWordsViaGUI();
    }


    // allow user to pick file to exam via GUI.
    // allow multiple picks
    public static void countWordsViaGUI() {
        setLookAndFeel();
        try {
            Scanner key = new Scanner(System.in);
            do {
                System.out.println("Opening GUI to choose file.");
                Scanner fileScanner = new Scanner(getFile());
                Stopwatch st = new Stopwatch();
                st.start();
                ArrayList<String> words = countWordsWithArrayList(fileScanner);
                st.stop();
                System.out.println("time to count: " + st);
                System.out.print("Enter number of words to display: ");
                int numWordsToShow = Integer.parseInt(key.nextLine());
                showWords(words, numWordsToShow);
                fileScanner.close();
                System.out.print("Perform another count? ");
            } while(key.nextLine().toLowerCase().charAt(0) == 'y');
            key.close();
        }
        catch(FileNotFoundException e) {
            System.out.println("Problem reading the data file. Exiting the program." + e);
        }
    }


    // determine distinct words in a file using an array list
    private static ArrayList<String> countWordsWithArrayList(Scanner fileScanner) {


        System.out.println("Total number of words: " + numWords);
        System.out.println("number of distincy words: " + result.size());
        return result;
    }


    // determine distinct words in a file and frequency of each word with a Map
    private static Map<String, Integer> countWordsWithMap(Scanner fileScanner) {


        System.out.println("Total number of words: " + numWords);
        System.out.println("number of distincy words: " + result.size());
        return result;
    }


    private static void showWords(ArrayList<String> words, int numWordsToShow) {
        for(int i = 0; i < words.size() && i < numWordsToShow; i++)
            System.out.println(words.get(i));
    }


    private static void showWords(Map<String, Integer> words, int numWordsToShow) {



    }


    // perform a series of experiments on files. Determine average time to
    // count words in files of various sizes
    private static void performExp() {
        String[] smallerWorks = {"smallWords.txt", "2BR02B.txt", "Alice.txt", "SherlockHolmes.txt"};;
        String[] bigFile = {"ciaFactBook2008.txt"};
        timingExpWithArrayList(smallerWorks, 50);
        timingExpWithArrayList(bigFile, 3);
        timingExpWithMap(smallerWorks, 50);
        timingExpWithMap(bigFile, 3);
    }


    // pre: titles != null, elements of titles refer to files in the
    // same path as this program, numExp >= 0
    // read words from files and print average time to cound words.
    private static void timingExpWithMap(String[] titles, int numExp) {
        try {
            double[] times = new double[titles.length];
            final int NUM_EXP = 50;
            for(int i = 0; i < NUM_EXP; i++) {
                for(int j = 0; j < titles.length; j++) {
                    Scanner fileScanner = new Scanner(new File(titles[j]));
                    Stopwatch st = new Stopwatch();
                    st.start();
                    Map<String, Integer> words = countWordsWithMap(fileScanner);
                    st.stop();
                    System.out.println(words.size());
                    times[j] += st.time();
                    fileScanner.close();
                }
            }
            for(double a : times)
                System.out.println(a / NUM_EXP);
        }
        catch(FileNotFoundException e) {
            System.out.println("Problem reading the data file. Exiting the program." + e);
        }
    }


    // pre: titles != null, elements of titles refer to files in the
    // same path as this program, numExp >= 0
    // read words from files and print average time to cound words.
    private static void timingExpWithArrayList(String[] titles, int numExp) {
        try {
            double[] times = new double[titles.length];
            for(int i = 0; i < numExp; i++) {
                for(int j = 0; j < titles.length; j++) {
                    Scanner fileScanner = new Scanner(new File(titles[j]));
                    Stopwatch st = new Stopwatch();
                    st.start();
                    ArrayList<String> words = countWordsWithArrayList(fileScanner);
                    st.stop();
                    times[j] += st.time();
                    fileScanner.close();
                }
            }
            for(int i = 0; i < titles.length; i++)
                System.out.println("Average time for " + titles[i] + ": " + (times[i] / numExp));
        }
        catch(FileNotFoundException e) {
            System.out.println("Problem reading the data file. Exiting the program." + e);
        }
    }


    // try to set look and feel to same as system
    private static void setLookAndFeel() {
        try {
            UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
        }
        catch(Exception e) {
            System.out.println("Unable to set look at feel to local settings. " +
            "Continuing with default Java look and feel.");
        }
    }


    /** Method to choose a file using a window.
     * @return the file chosen by the user. Returns null if no file picked.
     */
    private static File getFile() {
        // create a GUI window to pick the text to evaluate
        JFileChooser chooser = new JFileChooser(".");
        chooser.setDialogTitle("Select File To Count Words:");
        int retval = chooser.showOpenDialog(null);
        File f =null;
        chooser.grabFocus();
        if (retval == JFileChooser.APPROVE_OPTION)
            f = chooser.getSelectedFile();
        return f;
    }
}



package Solution;


import java.io.File;
import java.lang.reflect.Method;
import java.util.Arrays;
import java.util.Collection;
import java.util.HashSet;
import java.util.Scanner;
import java.util.TreeSet;

public class UnsortedSetTest {

    public static void main(String[] args) throws Exception {
        String[] allFileNames = {"hounds.txt", "huckfinn.txt", "oz.txt", "war.txt", "ciaFactBook2008.txt"};
        String[] noCIA = {"hounds.txt", "huckfinn.txt", "oz.txt", "war.txt"};
        countWords(new BinarySearchTree<String>(), allFileNames[0]);
        for(String s : allFileNames) {
            System.out.println(s);
            countWordsOurUnsortedSet(s);
            countWordsOurBinarySearchTree(s);
            countWordsOurHash(s);
            countWordsCollection(new TreeSet<String>(), s);
            int[] result = countWordsCollection(new HashSet<String>(), s);
            System.out.println(result[0] + " total words.");
            System.out.println(result[1] + " distinct words.");
            System.out.println();
            
        }
    }
    
    // return total num words, and num distinct words
    public static int[] countWordsCollection(Collection<String> c, String fileName) throws Exception{
        c.clear();
        Scanner fileScanner = new Scanner(new File(fileName));  
        Stopwatch st = new Stopwatch();
        st.start();
        int total = 0;
        while(fileScanner.hasNext()){
            c.add(fileScanner.next());
            total++;
        }
        st.stop();
        System.out.println("Time for " + c.getClass() + " : \n" + st);
//        System.out.println(c.size() + " distinct words");
//        System.out.println(total + " total words including duplicates: ");
        assert total >= c.size();
        System.out.println();
        return new int[]{total, c.size()};
    }
    
    
    // GACKY GACKY GACKY repition. Look into removing repetition with reflection
    // we assume there will be add and size methods
    public static int[] countWordsOurHash(String fileName) throws Exception {
        Scanner fileScanner = new Scanner(new File(fileName));  
        Stopwatch st = new Stopwatch();
        UnsortedHashSet<String> c = new UnsortedHashSet<String>();
        st.start();
        int total = 0;
        while(fileScanner.hasNext()) {
            c.add(fileScanner.next());
            total++;
        }
        st.stop();
        System.out.println("Time for our hashtable (closed address hashing): \n" + st);
//        System.out.println(c.size() + " distinct words");
//        System.out.println(total + " total words including duplicates: ");
        assert total >= c.size();
        System.out.println();
        return new int[]{total, c.size()};
    }
    
    public static int[] countWordsOurUnsortedSet(String fileName) throws Exception {
        Scanner fileScanner = new Scanner(new File(fileName));  
        Stopwatch st = new Stopwatch();
        UnsortedSet<String> c = new UnsortedSet<String>();
        st.start();
        int total = 0;
        while(fileScanner.hasNext()){
            c.add(fileScanner.next());
            total++;
        }
        st.stop();
        System.out.println("Time for our unsorted set based on ArrayList: \n" + st);
//        System.out.println(c.size() + " distinct words");
//        System.out.println(total + " total words including duplicates: ");
        assert total >= c.size();
        System.out.println();
        return new int[]{total, c.size()};
    }
    
    public static int[] countWordsOurBinarySearchTree(String fileName) throws Exception {
        Scanner fileScanner = new Scanner(new File(fileName));  
        Stopwatch st = new Stopwatch();
        BinarySearchTree<String> c = new BinarySearchTree<String>();
        st.start();
        int total = 0;
        while(fileScanner.hasNext()){
            c.add(fileScanner.next());
            total++;
        }
        st.stop();
        System.out.println("Time for our binary search tree: \n" + st);
//        System.out.println(c.size() + " distinct words");
//        System.out.println(total + " total words including duplicates: ");
        assert total >= c.size();
        System.out.println();
        return new int[]{total, c.size()};
    }
    
    
    // a try at reflection. Not working on Binary Search tree from class. 
    // Hunch. Due to add method taking in Comparable, not Object!
    // Alterantives: search list of methods for name?
    public static int[] countWords(Object c, String fileName) throws Exception {
        Scanner fileScanner = new Scanner(new File(fileName));  
        Stopwatch st = new Stopwatch();
        System.out.println(Arrays.toString(c.getClass().getMethods()));
        Method addMethod = c.getClass().getMethod("add", Object.class);
        st.start();
        int total = 0;
        while(fileScanner.hasNext()){
            addMethod.invoke(c, fileScanner.next());
            total++;
        }
        st.stop();
        System.out.println("Time for " + c.getClass() + ": "+ st);
        Method sizeMethod = c.getClass().getMethod("size");
        int distictWords = (Integer) sizeMethod.invoke(c);
//        System.out.println(distictWords + " distinct words");
//        System.out.println(total + " total words including duplicates: ");
        System.out.println();
        return new int[]{total, distictWords};
    }
}
}
