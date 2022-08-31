using System;

namespace ScorpionConsoleReadWrite
{
    internal /*static*/ struct Colors
    {
        //Defaults to colors:
        internal static ConsoleColor default_color = ConsoleColor.White,
        output_color = ConsoleColor.DarkYellow,
        error_color = ConsoleColor.Red,
        warning_color = ConsoleColor.DarkRed,
        success_color = ConsoleColor.Green,
        special_color = ConsoleColor.Blue,
        debug_color = ConsoleColor.Cyan,
        experimental_color = ConsoleColor.DarkMagenta;
    };

    public static class ConsoleWrite
    {
        //Set default colors to be used for specific outputs
        public static void setColors(ConsoleColor default_color, ConsoleColor output_color, ConsoleColor error_color, ConsoleColor warning_color, ConsoleColor success_color, ConsoleColor special_color, ConsoleColor debug_color, ConsoleColor experimental_color)
        {
            Colors.default_color = default_color;
            Colors.output_color = output_color;
            Colors.error_color = error_color;
            Colors.warning_color = warning_color;
            Colors.success_color = success_color;
            Colors.special_color = special_color;
            Colors.debug_color = debug_color;
            Colors.experimental_color = experimental_color;
            return;
        }
        
        //Write parameterized elements to console. Usually redirected here from one of the below public functions
        private static string writeParams(params string[] to_out)
        {
            string final = default;
            foreach(string s in to_out)
                final += s;
            return final;
        }

        public static void writeOutput(params string[] to_out)
        {
            consoleColor(Colors.output_color);
            Console.WriteLine(writeParams(to_out));
            defaultColor();
            return;
        }

        public static void writeSpecial(params string[] to_out)
        {
            consoleColor(Colors.special_color);
            Console.WriteLine(writeParams(to_out));
            defaultColor();
            return;
        }

        public static void writeSuccess(params string[] to_out)
        {
            consoleColor(Colors.success_color);
            Console.WriteLine(writeParams(to_out));
            defaultColor();
            return;
        }

        public static void writeError(params string[] to_out)
        {
            consoleColor(Colors.error_color);
            Console.WriteLine(writeParams(to_out));
            defaultColor();
            return;
        }
        
        public static void writeWarning(params string[] to_out)
        {
            consoleColor(Colors.warning_color);
            Console.WriteLine(writeParams(to_out));
            defaultColor();
            return;
        }
        
        public static void writeDebug(params string[] to_out)
        {
            consoleColor(Colors.debug_color);
            Console.WriteLine(writeParams(to_out));
            defaultColor();
            return;
        }

        //WRITE STRING
        public static void writeOutput(object to_out)
        {
            consoleColor(Colors.output_color);
            Console.WriteLine(to_out + "\n");
            defaultColor();
            return;
        }

        public static void writeError(object to_out)
        {
            consoleColor(Colors.error_color);
            Console.WriteLine("[ERROR]: {0}", to_out);
            defaultColor();
            return;
        }

        public static void writeWarning(object to_out)
        {
            consoleColor(Colors.warning_color);
            Console.WriteLine("[WARNING]: {0}", to_out);
            defaultColor();
            return;
        }

        public static void writeSpecial(object to_out)
        {
            consoleColor(Colors.special_color);
            Console.WriteLine("{0}", to_out);
            defaultColor();
            return;
        }

        public static void writeSuccess(object to_out)
        {
            consoleColor(Colors.success_color);
            Console.WriteLine("{0}", to_out);
            defaultColor();
            return;
        }

        public static void writeDebug(object to_out)
        {
            consoleColor(Colors.debug_color);
            if (to_out.GetType().Name == Type.GetType("byte[]").Name)
                foreach (byte b_ in (byte[])to_out)
                    Console.WriteLine("{0:X}", b_);
            else
                Console.WriteLine("[DEBUG]: {0}", to_out);
            defaultColor();
            return;
        }

        public static void writeVariadic(params string[] to_out)
        {
            string str_output = "";
            for(int i = 0; i < to_out.Length; i++)
                str_output += to_out;
            writeOutput(str_output);
            return;
        }

        public static void writeExperimental(object to_out)
        {
            consoleColor(Colors.experimental_color);
            if (to_out.GetType().Name == Type.GetType("byte[]").Name)
                foreach (byte b_ in (byte[])to_out)
                    Console.WriteLine("{0:X}", b_);
            else
                Console.WriteLine("[EXPERIMENTAL]: {0}", to_out);
            defaultColor();
            return;
        }

        internal static void consoleColor(ConsoleColor color_) => Console.ForegroundColor = color_;
        internal static void defaultColor() => Console.ForegroundColor = Colors.default_color;
    }

    public static class ConsoleRead
    {
        public static string ReadInput()
        {
            ConsoleWrite.writeSpecial("An external program is awaiting input, press CRTL+A to detatch from Squirrel for input");
            return Console.ReadLine();
        }
    }
}