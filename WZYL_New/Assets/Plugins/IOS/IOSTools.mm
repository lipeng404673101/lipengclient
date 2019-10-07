
@ interface IOSTools : NSObject

extern "C"
{
                 /*  compare the namelist with system processes  */
                 void _copyTextToClipboard(const char *textList);
}

@end@implementation IOSTools
//将文本复制到IOS剪贴板
- (void)objc_copyTextToClipboard : (NSString*)text
{
     UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
     pasteboard.string = text;
}
@end

extern "C" {
     static IOSTools *iosClipboard;
   
     void _copyTextToClipboard(const char *textList)
    {   
        NSString *text = [NSString stringWithUTF8String: textList] ;
       
        if(iosClipboard == NULL)
        {
            iosClipboard = [[IOSTools alloc] init];
        }
       
        [iosClipboard objc_copyTextToClipboard: text];
    }
}