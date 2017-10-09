using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace Raffle {
    [ExcludeFromCodeCoverage]
    class ViewApplicationContext : ApplicationContext {
        // Number of open forms
        private int windowCount = 0;

        // Singleton ApplicationContext
        private static ViewApplicationContext context;

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private ViewApplicationContext() {
        }

        /// <summary>
        /// Returns the one DemoApplicationContext.
        /// </summary>
        public static ViewApplicationContext GetContext() {
            if (context == null) {
                context = new ViewApplicationContext();
            }
            return context;
        }

        /// <summary>
        /// Runs a form in this application context
        /// </summary>
        public void RunNew() {
            // Create the window and the controller
            View window = new View();
            new Controller(window);

            // One more form is running
            windowCount++;

            // When this form closes, we want to find out
            window.FormClosed += (o, e) => { if (--windowCount <= 0) ExitThread(); };

            // Run the form
            window.Show();
        }

    }
}
