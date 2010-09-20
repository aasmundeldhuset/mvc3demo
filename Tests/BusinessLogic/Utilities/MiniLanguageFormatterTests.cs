using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BusinessLogic.Utilities;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Tests.BusinessLogic.Utilities
{
    class MiniLanguageFormatterTests
    {
        [Test]
        public void FormatShouldEscapeHtmlTags()
        {
            const string input = "<p>This<br/>is <b>bold</b></p>";
            const string expectedOutput = "&lt;p&gt;This&lt;br/&gt;is &lt;b&gt;bold&lt;/b&gt;&lt;/p&gt;";
            
            IHtmlString actualOutput = MiniLanguageFormatter.Format(input);
            
            Assert.That(actualOutput.ToHtmlString(), Text.Contains(expectedOutput));
        }

        [Test]
        public void FormatShouldEscapeHtmlEntities()
        {
            const string input = "'Here' & \"there\"";
            const string expectedOutput = "&#39;Here&#39; &amp; &quot;there&quot;";

            IHtmlString actualOutput = MiniLanguageFormatter.Format(input);

            Assert.That(actualOutput.ToHtmlString(), Text.Contains(expectedOutput));
        }

        [Test]
        public void FormatShouldTranslateBToStrong()
        {
            const string input = "This is [b]bold[/b]";
            const string expectedOutput = "This is <strong>bold</strong>";

            IHtmlString actualOutput = MiniLanguageFormatter.Format(input);

            Assert.That(actualOutput.ToHtmlString(), Text.Contains(expectedOutput));
        }

        [Test]
        public void FormatShouldTranslateIToEm()
        {
            const string input = "This is [i]italic[/i]";
            const string expectedOutput = "This is <em>italic</em>";

            IHtmlString actualOutput = MiniLanguageFormatter.Format(input);

            Assert.That(actualOutput.ToHtmlString(), Text.Contains(expectedOutput));
        }

        [Test]
        public void FormatShouldTranslateSupToSup()
        {
            const string input = "E = mc[sup]2[/sup]";
            const string expectedOutput = "E = mc<sup>2</sup>";

            IHtmlString actualOutput = MiniLanguageFormatter.Format(input);

            Assert.That(actualOutput.ToHtmlString(), Text.Contains(expectedOutput));
        }

        [Test]
        public void FormatShouldTranslateSubToSub()
        {
            const string input = "H[sub]2[/sub]O";
            const string expectedOutput = "H<sub>2</sub>O";

            IHtmlString actualOutput = MiniLanguageFormatter.Format(input);

            Assert.That(actualOutput.ToHtmlString(), Text.Contains(expectedOutput));
        }

        [Test]
        public void FormatShouldSurroundSingleParagraphWithP()
        {
            const string input = "One paragraph.";
            const string expectedOutput = "<p>One paragraph.</p>";

            IHtmlString actualOutput = MiniLanguageFormatter.Format(input);

            Assert.That(actualOutput.ToHtmlString(), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void FormatShouldSurroundEachParagraphWithP()
        {
            const string input = "First paragraph.\nSecond one. It contains two sentences.\n\nOne more.";
            const string expectedOutput = "<p>First paragraph.</p><p>Second one. It contains two sentences.</p><p></p><p>One more.</p>";

            IHtmlString actualOutput = MiniLanguageFormatter.Format(input);

            Assert.That(actualOutput.ToHtmlString(), Is.EqualTo(expectedOutput));
        }
    }
}
