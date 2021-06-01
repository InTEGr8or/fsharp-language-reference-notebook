open System.Text.RegularExpressions

Regex.Replace("""TESTF#<button type="button" class="action position-relative" data-bi-name="copy" aria-label="Copy code">
-             <span class="icon">
-                 <span class="docon docon-edit-copy" role="presentation"></span>
-             </span>
-             <span>Copy</span>
-             <div class="successful-copy-alert position-absolute right-0 top-0 left-0 bottom-0 display-flex align-items-center justify-content-center has-text-success-invert has-background-success is-transparent" aria-hidden="true">
-                 <span class="icon font-size-l">
-                     <span class="docon docon-check-mark" role="presentation"></span>
-                 </span>
-             </div>
-         </button>.TEST""", """F#<button[.\s\n\w\"=\-\<\>\/]*\<\/button\>""", "")