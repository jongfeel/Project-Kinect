﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kinect.Properties {
    using System;
    
    
    /// <summary>
    ///   지역화된 문자열 등을 찾기 위한 강력한 형식의 리소스 클래스입니다.
    /// </summary>
    // 이 클래스는 ResGen 또는 Visual Studio와 같은 도구를 통해 StronglyTypedResourceBuilder
    // 클래스에서 자동으로 생성되었습니다.
    // 멤버를 추가하거나 제거하려면 .ResX 파일을 편집한 다음 /str 옵션을 사용하여 ResGen을
    // 다시 실행하거나 VS 프로젝트를 다시 빌드하십시오.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   이 클래스에서 사용하는 캐시된 ResourceManager 인스턴스를 반환합니다.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Kinect.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   이 강력한 형식의 리소스 클래스를 사용하여 모든 리소스 조회에 대한 현재 스레드의 CurrentUICulture
        ///   속성을 재정의합니다.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   [키넥트 탐색중] 자동으로 키넥트를 찾는 중입니다.과(와) 유사한 지역화된 문자열을 찾습니다.
        /// </summary>
        internal static string AutoReconnecting {
            get {
                return ResourceManager.GetString("AutoReconnecting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   [키넥트 송출중] 키넥트가 성공적으로 연결되었습니다.과(와) 유사한 지역화된 문자열을 찾습니다.
        /// </summary>
        internal static string KinectConnected {
            get {
                return ResourceManager.GetString("KinectConnected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   [키넥트 준비중] 송출까지 15초 정도의 시간이 소요될 수 있습니다.과(와) 유사한 지역화된 문자열을 찾습니다.
        /// </summary>
        internal static string KinectLoading {
            get {
                return ResourceManager.GetString("KinectLoading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   [키넥트 인식 장애] 다시 준비중입니다... 5초내로 변화가 없으면 키넥트 USB를 다시 연결하여 주십시오.과(와) 유사한 지역화된 문자열을 찾습니다.
        /// </summary>
        internal static string ReconnectRequired {
            get {
                return ResourceManager.GetString("ReconnectRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Failed to write screenshot to과(와) 유사한 지역화된 문자열을 찾습니다.
        /// </summary>
        internal static string ScreenshotWriteFailed {
            get {
                return ResourceManager.GetString("ScreenshotWriteFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Screenshot saved to과(와) 유사한 지역화된 문자열을 찾습니다.
        /// </summary>
        internal static string ScreenshotWriteSuccess {
            get {
                return ResourceManager.GetString("ScreenshotWriteSuccess", resourceCulture);
            }
        }
    }
}