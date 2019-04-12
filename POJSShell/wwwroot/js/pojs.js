// requires jquery

var m_ver = 1.0;
var m_textarea = null;


function pojs_clear()
{
    m_textarea.value = "";
}
function pojs_init(textarea)
{
    m_textarea = textarea;
    pojs_clear();
    pojs_outstrd("pojs initialized - v" + m_ver);
}

function pojs_outstr(msg)
{
    var outstr;
    outstr = "";

    if (m_textarea.value.length > 0)
    {
        outstr = "\r\n";
    }
    outstr += msg;

    m_textarea.value += outstr;
}
function pojs_outstrd( msg )
{
    var d = new Date();
    var outstr;
    outstr = d.toUTCString() + " >> " + msg;
    pojs_outstr(outstr);
}

function pojs_ver() {
    return m_ver;
}